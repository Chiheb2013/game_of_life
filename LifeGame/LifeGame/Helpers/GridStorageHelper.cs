﻿#define LOG
#undef LOG

using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

using Mappy;

namespace LifeGame
{
    class GridStorageHelper
    {
        public event Action<int> BitsIterationPassed;
        public event Action<int> CellsIterationPassed;

#if LOG
        string logPath = string.Empty;
        StringBuilder logger = new StringBuilder();
#endif

        public void SaveGrid(Grid grid, string to)
        {
            try
            {
#if LOG
                logPath = Path.Combine(to.Replace(Path.GetFileName(to), ""), "log.txt");
#endif
                using (FileStream fs = File.Create(to))
                {
                    StringBuilder bits = new StringBuilder();
                    
                    if (grid is HexagonalGrid)
                        SaveHexagonalGrid(grid, fs, bits);
                    else
                        SaveRegularGrid(grid, fs, bits);

#if LOG
                    File.WriteAllText(logPath, logger.ToString());
#endif
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SaveRegularGrid(Grid grid, FileStream fs, StringBuilder bits)
        {
            fs.WriteByte(0);
#if LOG
            logger.AppendLine("Grid type : regular = 0");
#endif
            WriteGridProperties(grid, fs);

            bits.Append(grid.Cells[0].Alive ? '1' : '0');
            for (int i = 1; i < grid.Cells.Length; i++)
            {
                bits.Append(grid.Cells[i].Alive ? '1' : '0');

                if (i % sizeof(long) == 0)
                {
                    string binary = bits.ToString().Reverse();
                    byte octopus = Convert.ToByte(binary, 2);
                    fs.WriteByte(octopus);

#if LOG
                    logger.AppendLine("Bits { " + binary + " } = " + octopus);
#endif

                    bits.Clear();
                }
            }
        }

        private void SaveHexagonalGrid(Grid grid, FileStream fs, StringBuilder bits)
        {
            fs.WriteByte(1);
#if LOG
            logger.AppendLine("Grid type : hexagonal = 1");
#endif
            HexagonalGrid hexa = (HexagonalGrid)grid;

            WriteGridProperties(hexa, fs);

            bits.Append(hexa.Cells[0].Alive ? '1' : '0');
            for (int i = 1; i < hexa.Cells.Length; i++)
            {
                bits.Append(hexa.Cells[i].Alive ? '1' : '0');

                if (i % sizeof(long) == 0)
                {
                    string binary = bits.ToString().Reverse();
                    byte octopus = Convert.ToByte(binary, 2);
                    fs.WriteByte(octopus);

#if LOG
                    logger.AppendLine("Bits { " + binary + " } = " + octopus);
#endif

                    bits.Clear();
                }
            }
        }

        private void WriteGridProperties(Grid grid, FileStream fs)
        {
            fs.WriteByte((byte)grid.Width);
            fs.WriteByte((byte)grid.Height);

#if LOG
            logger.AppendLine("Width = " + grid.Width);
            logger.AppendLine("Height = " + grid.Height);
#endif

            WriteGridIteration(grid.Iteration, fs);
        }

        private void WriteGridIteration(int iteration, FileStream fs)
        {
            StringBuilder lengthBinary = new StringBuilder((Convert.ToString(iteration, 2).AdjustNumberOfBitsToN()));

            string[] parts = CutStringBuilderInFour(ref lengthBinary);

#if LOG
            logger.AppendLine("Iteration { " + lengthBinary.ToString() + " } = " + iteration);
            logger.AppendLine("Parts {");
            foreach (string part in parts)
                logger.AppendLine("\t{ " + part + " }");
            logger.AppendLine("}");
#endif

            fs.WriteByte(Convert.ToByte(parts[0], 2));
            fs.WriteByte(Convert.ToByte(parts[1], 2));
            fs.WriteByte(Convert.ToByte(parts[2], 2));
            fs.WriteByte(Convert.ToByte(parts[3], 2));
        }

        private string[] CutStringBuilderInFour(ref StringBuilder lengthBinary)
        {
            lengthBinary.Insert(8, " ");
            lengthBinary.Insert(17, " ");
            lengthBinary.Insert(26, " ");

            return lengthBinary.ToString().Split(' ');
        }

        public Grid LoadGrid(string from)
        {
            try
            {
                using (FileStream fs = File.OpenRead(from))
                {
                    int gridType = fs.ReadByte();

#if LOG
                    logger.AppendLine("- Loading :" + Environment.NewLine +
                        "grid type : " + gridType);
#endif

                    if (gridType == 0)
                        return LoadRegularGrid(fs);
                    else
                        return LoadHexagonalGrid(fs);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Grid LoadRegularGrid(FileStream fs)
        {
            int width = fs.ReadByte();
            int height = fs.ReadByte();
            int sequenceLength = width * height / sizeof(long);
            int gridArea = width * height;
            int iteration = ReadGridIteration(fs);

#if LOG
            logger.AppendLine("width : " + width);
            logger.AppendLine("height : " + height);
            logger.AppendLine("seq. length = " + sequenceLength);
            logger.AppendLine("area : " + gridArea);
            logger.AppendLine("iteration : " + iteration);
#endif

            List<int> cellsLifeStates = GetCellsLifeState(fs, sequenceLength);

#if LOG
            File.WriteAllText("log.txt", logger.ToString());
#endif

            List<Cell> cells = CreateCells(width, gridArea, cellsLifeStates);

            Grid grid = new Grid(new Point(width, height), cells.ToArray(), iteration);
            SetCellsParent(grid);

            return grid;
        }

        private HexagonalGrid LoadHexagonalGrid(FileStream fs)
        {
            int width = fs.ReadByte();
            int height = fs.ReadByte();
            int gridArea = width * height;
            int iteration = ReadGridIteration(fs);
            int sequenceLength = width * height / sizeof(long);

#if LOG
            logger.AppendLine("width : " + width);
            logger.AppendLine("height : " + height);
            logger.AppendLine("seq. length = " + sequenceLength);
            logger.AppendLine("area : " + gridArea);
            logger.AppendLine("iteration : " + iteration);
#endif

            List<int> cellsLifeStates = GetCellsLifeState(fs, sequenceLength);

#if LOG
            File.WriteAllText("log.txt", logger.ToString());
#endif

            List<HexagonalCell> cells = CreateHexagonalCells(width, gridArea, cellsLifeStates);

            HexagonalGrid hexa = new HexagonalGrid(new Vector2D(width, height), cells.ToArray(), iteration);
            SetCellsParent(hexa);

            return hexa;
        }

        private static void SetCellsParent(Grid grid)
        {
            foreach (Cell cell in grid.Cells)
                cell.Parent = grid;
        }

        private int ReadGridIteration(FileStream fs)
        {
            byte[] bytes = new byte[4];
            fs.Read(bytes, 0, 4);

            string iterationBinary = GetBinaryFromByte(bytes[0])
                                    + GetBinaryFromByte(bytes[1])
                                    + GetBinaryFromByte(bytes[2])
                                    + GetBinaryFromByte(bytes[3]);
            return Convert.ToInt32(iterationBinary, fromBase: 2);
        }

        private List<int> GetCellsLifeState(FileStream fs, int sequenceLength)
        {
#if LOG
            logger.AppendLine(" -- Cell life states loading");
#endif
            List<int> cells = new List<int>();

            int i = 0;
            int percent;
            byte[] data = new byte[sequenceLength];
            fs.Read(data, 0, sequenceLength);

            foreach (byte oct in data)
            {
                string bits = Convert.ToString(oct, toBase: 2).AdjustNumberOfBitsToN(sizeof(long));
                foreach (char bit in bits)
                    cells.Add(bit == '1' ? 1 : 0);
                percent = (int)((float)i++ / (float)sequenceLength * 100.0f);

#if LOG
                logger.AppendLine("\t{ " + bits + " }\t" + percent + " %");
#endif

                RaiseBitsIterationEvent(percent + 1);
            }

#if LOG
            logger.AppendLine("-- Cells summary :");
            foreach (int cell in cells)
                logger.Append(cell);
            logger.AppendLine(Environment.NewLine + "Total cells : " + cells.Count);
            logger.AppendLine("Cells by sizeof(long) : " + (cells.Count / sizeof(long)).ToString());
#endif

            return cells;
        }

        private List<Cell> CreateCells(int width, int gridArea, List<int> cells)
        {
            List<Cell> acells = new List<Cell>();
            for (int i = 0; i < gridArea; i++)
            {
                Vector2D v = CoordinateSystemConverter.LineToPlane(i, width);
                acells.Add(new Cell(new Point((int)v.X, (int)v.Y), cells[i] == 1));

                RaiseIterationEvent(gridArea, i);
            }
            return acells;
        }

        private List<HexagonalCell> CreateHexagonalCells(int width, int gridArea, List<int> states)
        {
            List<HexagonalCell> cells = new List<HexagonalCell>();
            for (int i = 0; i < gridArea; i++)
            {
                Vector2D v = CoordinateSystemConverter.LineToPlane(i, width);
                cells.Add(new HexagonalCell(new Vector2D(v.X, v.Y), new Vector2D(10, 20), states[i] == 1));

                RaiseIterationEvent(gridArea, i);
            }
            return cells;
        }

        private void RaiseIterationEvent(int gridArea, int i)
        {
            double percent = (double)i / (double)gridArea * 100.0;
            RaiseCellsIterationEvent((int)percent + 1);
        }

        private void RaiseBitsIterationEvent(int percent)
        {
            if (BitsIterationPassed != null)
                BitsIterationPassed(percent);
        }

        private void RaiseCellsIterationEvent(int percent)
        {
            if (CellsIterationPassed != null)
                CellsIterationPassed(percent);
        }

        private string GetBinaryFromByte(byte byteValue)
        {
            return Convert.ToString(byteValue, toBase: 2).AdjustNumberOfBitsToN(8);
        }
    }
}
