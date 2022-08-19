using System;
using System.Collections.Generic;

namespace Program
{
    public class Table {

        public List<String>[] columns;
        private int columnSize = 0;


        // creates list and set properties
        public Table(int col) {
            columns = new List<String>[col];
            for (int i = 0; i < col; i++)
            {
                columns[i] = new List<String>();
            }
            columnSize = col;
        }


        // add columns to list
        public void addColum(String[] line) {
            if (!(line.Length == columnSize)) {
                new Exception("Attempted at adding line but line has a different size from columns of the table");
                return;
            }

            for(int i = 0; i < columnSize; i++) {
                columns[i].Add(line[i]);
            }
        }

        // get max length of columns
        private int getMaxLength(String[] colum) {
            int m = 0;
            foreach (String s in colum) {
                if(s.Length > m) {
                    m = s.Length;
                }
            }
            return m;
        }

        // gets columns and convert to string array
        public String[] getColumns(int col) {
            return columns[col].ToArray();
        }


        // creates list
        public String getList() {
            String table = "";

            int[] vs = new int[columnSize];
            for(int i = 0; i < columnSize;i++) {
                vs[i] = getMaxLength(getColumns(i));
            }

            // top
            table += "╔";
            for (int i = 0; i < vs.Length; i++) {
                table += new String('═', vs[i]);
                if(i < vs.Length - 1)
                {
                    table += "╦";
                }
            }
            table += "╗\n";

            // lines and data
            int ROWS = columns[0].Count;

            for (int i = 0; i < ROWS; i++) {

                table += "║";
                for (int j = 0; j < vs.Length; j++)
                {
                    int mx = vs[j];
                    int spaces = mx - columns[j][i].Length;
                    table += columns[j][i];

                    if(spaces > 0)
                    {
                        table += new string(' ', spaces);
                    }

                    if (j < vs.Length - 1)
                    {
                        table += "║";
                    }
                }
                table += "║\n";

                if( i < ROWS - 1)
                {
                    table += "╠";
                    for (int j = 0; j < vs.Length; j++)
                    {
                        table += new String('═', vs[j]);
                        if (j < vs.Length - 1)
                        {
                            table += "╬";
                        }
                    }
                    table += "╣\n";
                }
            }

            // bottom
            table += "╚";
            for (int i = 0; i < vs.Length; i++)
            {
                table += new string('═', vs[i]);
                if (i < vs.Length - 1)
                {
                    table += "╩";
                }
            }
            table += "╝\n";



            return table;
        }
    }
}
