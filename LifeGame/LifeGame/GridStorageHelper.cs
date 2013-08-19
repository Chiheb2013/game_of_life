using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

using Mappy;

namespace LifeGame
{
    static class GridStorageHelper
    {
        public static void SaveGrid(Grid grid, string to)
        {
            try
            {
                using (FileStream fs = File.Create(to))
                {
                    StringBuilder bits = new StringBuilder();

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

                            bits.Clear();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void WriteGridProperties(Grid grid, FileStream fs)
        {
            fs.WriteByte((byte)grid.Width);
            fs.WriteByte((byte)grid.Height);

            WriteGridIteration(grid.Iteration, fs);
        }

        private static void WriteGridIteration(int iteration, FileStream fs)
        {
            StringBuilder lengthBinary = new StringBuilder((Convert.ToString(iteration, 2).AdjustNumberOfBitsToN()));

            string[] parts = CutStringBuilderInFour(ref lengthBinary);

            fs.WriteByte(Convert.ToByte(parts[0], 2));
            fs.WriteByte(Convert.ToByte(parts[1], 2));
            fs.WriteByte(Convert.ToByte(parts[2], 2));
            fs.WriteByte(Convert.ToByte(parts[3], 2));
        }

        private static string[] CutStringBuilderInFour(ref StringBuilder lengthBinary)
        {
            lengthBinary.Insert(8, " ");
            lengthBinary.Insert(17, " ");
            lengthBinary.Insert(26, " ");

            return lengthBinary.ToString().Split(' ');
        }

        public static Grid LoadGrid(string from)
        {
            try
            {
                using (FileStream fs = File.OpenRead(from))
                {
                    int width = fs.ReadByte();
                    int height = fs.ReadByte();
                    int sequenceLength = width * height / sizeof(long);
                    int gridArea = width * height;
                    int iteration = ReadGridIteration(fs);

                    List<int> cellsLifeStates = GetCellsLifeState(fs, sequenceLength);
                    List<Cell> cells = CreateCells(width, gridArea, cellsLifeStates);

                    Grid grid = new Grid(new Point(width, height), cells.ToArray(), iteration);
                    return grid;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static int ReadGridIteration(FileStream fs)
        {
            byte[] bytes = new byte[4];
            fs.Read(bytes, 0, 4);

            string iterationBinary = GetBinaryFromByte(bytes[0])
                                    + GetBinaryFromByte(bytes[1])
                                    + GetBinaryFromByte(bytes[2])
                                    + GetBinaryFromByte(bytes[3]);
            return Convert.ToInt32(iterationBinary, fromBase: 2);
        }

        private static List<int> GetCellsLifeState(FileStream fs, int sequenceLength)
        {
            List<int> cells = new List<int>();
            for (int i = 0; i < sequenceLength; i++)
            {
                string bits = Convert.ToString(fs.ReadByte(), toBase: 2).AdjustNumberOfBitsToN(sizeof(long));
                foreach (char bit in bits)
                    cells.Add(bit == '1' ? 1 : 0);
            }
            return cells;
        }

        private static List<Cell> CreateCells(int width, int gridArea, List<int> cells)
        {
            List<Cell> acells = new List<Cell>();
            for (int i = 0; i < gridArea; i++)
            {
                Vector2D v = CoordinateSystemConverter.LineToPlane(i, width);
                acells.Add(new Cell(new Point((int)v.X, (int)v.Y), cells[i] == 1));
            }
            return acells;
        }

        private static string GetBinaryFromByte(byte byteValue)
        {
            return Convert.ToString(byteValue, toBase: 2).AdjustNumberOfBitsToN(8);
        }
    }
}
