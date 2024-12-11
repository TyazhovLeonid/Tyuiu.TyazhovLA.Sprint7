using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.TyazhovLA.Sprint7.Project.V1.Lib;
namespace Project.V1
{
    public partial class FormMain : Form
    {
        static string openFilePath;
        static int rows;
        static int columns;
        DataService ds = new DataService();
        public FormMain()
        {
            InitializeComponent();
            toolStripMenuItemRed_TLA.Click += MenuItem_Click;
            toolStripMenuItemBlue_TLA.Click += MenuItem_Click;
            toolStripMenuItemGray_TLA.Click += MenuItem_Click;
            toolStripMenuItemWhite_TLA.Click += MenuItem_Click;
            toolStripMenuItemBlack_TLA.Click += MenuItem_Click;
            toolStripMenuItemBMW_TLA.Click += MenuItem_Click;
            toolStripMenuItemNissan_TLA.Click += MenuItem_Click;
            toolStripMenuItemLADA_TLA.Click += MenuItem_Click;
            toolStripMenuItemMersedes_TLA.Click += MenuItem_Click;
            toolStripMenuItemToyota_TLA.Click += MenuItem_Click;
            toolStripMenuItemFerrari_TLA.Click += MenuItem_Click;
            toolStripMenuItem100_TLA.Click += MenuItem_Click;
            toolStripMenuItem100200_TLA.Click += MenuItem_Click;
            toolStripMenuItem200300_TLA.Click += MenuItem_Click;
            toolStripMenuItem300AndMore_TLA.Click += MenuItem_Click;

        }

        private void buttonHelp_TLA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonSortByBrand_TLA_Click(object sender, EventArgs e)
        {
            contextMenuStripBrand_TLA.Show(buttonSortByBrand_TLA, new Point(0, buttonSortByBrand_TLA.Height));
        }
        #region MouseEnterTips
        private void buttonSortByColor_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonSortByColor_TLA, "Фильтровать по цвету автомобиля");
        }

        private void buttonSortByBrand_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonSortByBrand_TLA, "Фильтровать по марке автомобиля");
        }

        private void buttonSortByPower_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonSortByPower_TLA, "Фильтровать по мощности двигателя");
        }

        private void buttonSearchByNumber_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonSearchByNumber_TLA, "Поиск автомобиля по гос. номеру");
        }

        private void buttonHelp_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonHelp_TLA, "Справка");
        }

        private void buttonOpenFile_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonOpenFile_TLA, "Открыть базу данных");
        }

        private void buttonSaveResult_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonSaveResult_TLA, "Сохранить результат в файл");
        }


        private void buttonCreateChart_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonCreateChart_TLA, "Построить диаграмму");
        }

        private void buttonStats_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonStats_TLA, "Вывести статистику");
        }
        private void buttonGuide_TLA_MouseEnter(object sender, EventArgs e)
        {
            toolTip_TLA.SetToolTip(buttonGuide_TLA, "Руководство пользователя");
        }
        #endregion


        public static string[,] LoadFromFileData(string FilePath)
        {
            string fileData = File.ReadAllText(FilePath);

            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            rows = lines.Length;
            columns = lines[0].Split(';').Length;

            string[,] data = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] line = lines[i].Split(";");
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = line[j];
                }
            }
            return data;
        }


        private void buttonOpenFile_TLA_Click(object sender, EventArgs e)
        {
            openFileDialogTask_TLA.ShowDialog();
            openFilePath = openFileDialogTask_TLA.FileName;

            string[,] data = new string[rows, columns];

            data = LoadFromFileData(openFilePath);

            dataGridViewInput_TLA.ColumnCount = columns;
            dataGridViewInput_TLA.RowCount = rows + 1;
            dataGridViewOutput_TLA.ColumnCount = columns;
            dataGridViewOutput_TLA.RowCount = rows;

            for (int h = 0; h < columns; h++)
            {
                dataGridViewInput_TLA.Columns[h].Width = 190;
                dataGridViewOutput_TLA.Columns[h].Width = 190;
            }

            dataGridViewInput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
            dataGridViewInput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
            dataGridViewInput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
            dataGridViewInput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";
            dataGridViewInput_TLA.Rows[0].Height = 50;

            int r = 1;
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    dataGridViewInput_TLA.Rows[r].Cells[j].Value = data[i, j];

                }
                r++;
            }
            buttonSortByBrand_TLA.Enabled = true;
            buttonSortByColor_TLA.Enabled = true;
            buttonSortByPower_TLA.Enabled = true;
            buttonCreateChart_TLA.Enabled = true;
            buttonStats_TLA.Enabled = true;
            buttonSearchByNumber_TLA.Enabled = true;
            buttonSaveResult_TLA.Enabled = true;
        }

        private void buttonSortByColor_TLA_Click(object sender, EventArgs e)
        {
            contextMenuStripColor_TLA.Show(buttonSortByColor_TLA, new Point(0, buttonSortByColor_TLA.Height));
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            string[,] data = new string[rows, columns];
            data = LoadFromFileData(openFilePath);

            dataGridViewOutput_TLA.ColumnCount = columns;
            dataGridViewOutput_TLA.RowCount = rows;

            for (int h = 0; h < columns; h++)
            {
                dataGridViewInput_TLA.Columns[h].Width = 190;
                dataGridViewOutput_TLA.Columns[h].Width = 190;
            }

            dataGridViewOutput_TLA.Rows[0].Height = 50;

            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;


            switch (selectedItem.Text)
            {
                case "Красный":
                    int r = 1;
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 2] == "Красный")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }

                    }
                    break;

                case "Синий":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";


                    r = 1;
                    for (int i = 1; i < rows; i++)
                    {
                        if (data[i, 2] == "Синий")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;

                case "Белый":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 1; i < rows; i++)
                    {
                        if (data[i, 2] == "Белый")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;

                case "Серый":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 1; i < rows; i++)
                    {
                        if (data[i, 2] == "Серый")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    };
                    break;
                case "Черный":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 2] == "Черный")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "BMW":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "BMW")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "Mersedes":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "Mersedes")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "Toyota":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "Toyota")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "Nissan":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "Nissan")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "Ferrari":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "Ferrari")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "LADA":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (data[i, 1] == "LADA")
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "0-100":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (Convert.ToInt32(data[i, 3]) >= 0 && Convert.ToInt32(data[i, 3]) <= 100)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "100-200":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (Convert.ToInt32(data[i, 3]) >= 100 && Convert.ToInt32(data[i, 3]) <= 200)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case "200-300":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (Convert.ToInt32(data[i, 3]) >= 200 && Convert.ToInt32(data[i, 3]) <= 300)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
                case ">300":
                    dataGridViewOutput_TLA.Rows.Clear();
                    dataGridViewOutput_TLA.ColumnCount = columns;
                    dataGridViewOutput_TLA.RowCount = rows;
                    dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                    dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                    r = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        if (Convert.ToInt32(data[i, 3]) >= 300)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                            }
                            r++;
                        }
                    }
                    break;
            }
        }

        private void buttonSortByPower_TLA_Click(object sender, EventArgs e)
        {
            contextMenuStripPower_TLA.Show(buttonSortByPower_TLA, new Point(0, buttonSortByPower_TLA.Height));
        }

        private void buttonSaveResult_TLA_Click(object sender, EventArgs e)
        {
            saveFileDialog_TLA.FileName = "file.csv";
            saveFileDialog_TLA.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog_TLA.ShowDialog();
            

            string path = saveFileDialog_TLA.FileName;

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                File.Delete(path);
            }

            string str = "";
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (dataGridViewOutput_TLA.Rows[i].Cells[j].Value.ToString() == "") break;
                        if (j != columns - 1)
                        {
                            str += dataGridViewOutput_TLA.Rows[i].Cells[j].Value + ";";
                        }
                        else
                        {
                            str += dataGridViewOutput_TLA.Rows[i].Cells[j].Value;
                        }
                    }
                    File.AppendAllText(path, str + Environment.NewLine);
                    str = "";
                }
            } catch { }
        }

        private void buttonStats_TLA_Click(object sender, EventArgs e)
        {


            string[,] data = new string[rows, columns];

            data = LoadFromFileData(openFilePath);

            dataGridViewStats_TLA.ColumnCount = 2;
            dataGridViewStats_TLA.RowCount = 6;



            dataGridViewStats_TLA.Rows[0].Cells[0].Value = "Общее кол-во машин";
            dataGridViewStats_TLA.Rows[1].Cells[0].Value = "Преобладающий цвет машин";
            dataGridViewStats_TLA.Rows[2].Cells[0].Value = "Преобладающая марка машин";
            dataGridViewStats_TLA.Rows[3].Cells[0].Value = "Средняя мощность двигателя";
            dataGridViewStats_TLA.Rows[4].Cells[0].Value = "Максимальная мощность двигателя";
            dataGridViewStats_TLA.Rows[5].Cells[0].Value = "Минимальная мощность двигателя";
            dataGridViewStats_TLA.Columns[0].Width = 300;
            dataGridViewStats_TLA.Columns[1].Width = 100;
            dataGridViewStats_TLA.Rows[0].Cells[1].Value = dataGridViewInput_TLA.Rows.Count - 1;
            int red = 0;
            int blue = 0;
            int gray = 0;
            int white = 0;
            int black = 0;
            int toyota = 0;
            int ferrari = 0;
            int lada = 0;
            int nissan = 0;
            int bmw = 0;
            int mersedes = 0;
            double AveragePower = 0;
            int maxPower = 0;
            int minPower = 1000;
            for (int i = 0; i < rows; i++)
            {
                switch (data[i, 2])
                {
                    case "Красный":
                        red++; break;
                    case "Синий":
                        blue++; break;
                    case "Серый":
                        gray++; break;
                    case "Белый":
                        white++; break;
                    case "Черный":
                        black++; break;
                }
                switch (data[i, 1])
                {
                    case "BMW":
                        bmw++; break;
                    case "Toyota":
                        toyota++; break;
                    case "Mersedes":
                        mersedes++; break;
                    case "LADA":
                        lada++; break;
                    case "Nissan":
                        nissan++; break;
                    case "Ferrari":
                        ferrari++; break;

                }
                AveragePower += Convert.ToInt32(data[i, 3]);
                if (Convert.ToInt32(data[i, 3]) >= maxPower) maxPower = Convert.ToInt32(data[i, 3]);
                if (Convert.ToInt32(data[i, 3]) <= minPower) minPower = Convert.ToInt32(data[i, 3]);
            }
            AveragePower = Math.Round(AveragePower / (dataGridViewInput_TLA.Rows.Count - 1), 2);
            string color;
            int maxcolor = Math.Max(red, (Math.Max(blue, Math.Max(white, Math.Max(gray, black)))));
            if (maxcolor == red) dataGridViewStats_TLA.Rows[1].Cells[1].Value = "Красный";
            if (maxcolor == blue) dataGridViewStats_TLA.Rows[1].Cells[1].Value = "Синий";
            if (maxcolor == white) dataGridViewStats_TLA.Rows[1].Cells[1].Value = "Белый";
            if (maxcolor == black) dataGridViewStats_TLA.Rows[1].Cells[1].Value = "Черный";
            if (maxcolor == gray) dataGridViewStats_TLA.Rows[1].Cells[1].Value = "Серый";
            int maxbrand = Math.Max(toyota, (Math.Max(nissan, Math.Max(bmw, Math.Max(lada, Math.Max(ferrari, mersedes))))));
            if (maxbrand == toyota) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "Toyota";
            if (maxbrand == bmw) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "BMW";
            if (maxbrand == mersedes) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "Mersedes";
            if (maxbrand == lada) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "LADA";
            if (maxbrand == nissan) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "Nissan";
            if (maxbrand == ferrari) dataGridViewStats_TLA.Rows[2].Cells[1].Value = "Ferrari";
            dataGridViewStats_TLA.Rows[3].Cells[1].Value = Convert.ToString(AveragePower);
            dataGridViewStats_TLA.Rows[4].Cells[1].Value = Convert.ToString(maxPower);
            dataGridViewStats_TLA.Rows[5].Cells[1].Value = Convert.ToString(minPower);
        }

        private void buttonSearchByNumber_TLA_Click(object sender, EventArgs e)
        {
            FormSearch FormSearch = new FormSearch();
            FormSearch.ShowDialog();
            FormSearch textBoxSearch = new FormSearch();
            try
            {
                string[,] data = new string[rows, columns];

                data = LoadFromFileData(openFilePath);
                int r = 1;
                dataGridViewOutput_TLA.Rows.Clear();
                dataGridViewOutput_TLA.ColumnCount = columns;
                dataGridViewOutput_TLA.RowCount = rows;
                dataGridViewOutput_TLA.Rows[0].Cells[0].Value = "Гос. номер автомобиля";
                dataGridViewOutput_TLA.Rows[0].Cells[1].Value = "Марка автомобиля";
                dataGridViewOutput_TLA.Rows[0].Cells[2].Value = "Цвет автомобиля";
                dataGridViewOutput_TLA.Rows[0].Cells[3].Value = "Мощность двигателя, л.с.";

                for (int i = 0; i < rows; i++)
                {
                    if (data[i, 0] == DataBank.text)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            dataGridViewOutput_TLA.Rows[r].Cells[j].Value = data[i, j];
                        }
                        r++;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Номер введен неверно или машины с таким номером нет в автомастерской", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateChart_TLA_Click(object sender, EventArgs e)
        {
            string[,] data = new string[rows, columns];

            data = LoadFromFileData(openFilePath);

            this.chartStats_TLA.ChartAreas[0].AxisX.Title = "Марка автомобиля";
            this.chartStats_TLA.ChartAreas[0].AxisY.Title = "Средняя мощность двигателя";

            double averagePowerToyota = 0;
            int toyotacount = 0; int nissancount = 0; int bmwcount = 0; int ladacount = 0; int mersedescount = 0; int ferraricount = 0;
            double averagePowerNissan = 0;
            double averagePowerMersedes = 0;
            double averagePowerBMW = 0;
            double averagePowerLADA = 0;
            double averagePowerFerrari = 0;

            for (int i = 0; i < rows; i++)
            {
                if (data[i, 1] == "Toyota")
                {
                    averagePowerToyota += Convert.ToInt32(data[i, 3]);
                    toyotacount++;
                }
                if (data[i, 1] == "BMW")
                {
                    averagePowerBMW += Convert.ToInt32(data[i, 3]);
                    bmwcount++;
                }
                if (data[i, 1] == "Mersedes")
                {
                    averagePowerMersedes += Convert.ToInt32(data[i, 3]);
                    mersedescount++;
                }
                if (data[i, 1] == "Nissan")
                {
                    averagePowerNissan += Convert.ToInt32(data[i, 3]);
                    nissancount++;
                }
                if (data[i, 1] == "LADA")
                {
                    averagePowerLADA += Convert.ToInt32(data[i, 3]);
                    ladacount++;
                }
                if (data[i, 1] == "Ferrari")
                {
                    averagePowerFerrari += Convert.ToInt32(data[i, 3]);
                    ferraricount++;
                }
            }



            averagePowerToyota = Math.Round(averagePowerToyota / toyotacount, 2);
            averagePowerNissan = Math.Round(averagePowerNissan / nissancount, 2);
            averagePowerMersedes = Math.Round(averagePowerMersedes / mersedescount, 2);
            averagePowerLADA = Math.Round(averagePowerLADA / ladacount, 2);
            averagePowerFerrari = Math.Round(averagePowerFerrari / ferraricount, 2);
            averagePowerBMW = Math.Round(averagePowerBMW / bmwcount, 2);
            /* this.chartStats_TLA.Series[0].Points.AddXY("Toyota", averagePowerToyota);
             this.chartStats_TLA.Series[0].Points.AddXY("BMW", averagePowerBMW);
             this.chartStats_TLA.Series[0].Points.AddXY("Mersedes", averagePowerMersedes);
             this.chartStats_TLA.Series[0].Points.AddXY("Nissan", averagePowerNissan);
             this.chartStats_TLA.Series[0].Points.AddXY("LADA", averagePowerLADA);
             this.chartStats_TLA.Series[0].Points.AddXY("Ferrari", averagePowerFerrari);*/

            this.chartStats_TLA.Series.Add("Toyota");
            this.chartStats_TLA.Series.Add("BMW");
            this.chartStats_TLA.Series.Add("Mersedes");
            this.chartStats_TLA.Series.Add("Nissan");
            this.chartStats_TLA.Series.Add("LADA");
            this.chartStats_TLA.Series.Add("Ferrari");


            foreach (Series series in this.chartStats_TLA.Series)
            {
                series.ChartType = SeriesChartType.Column;
            }


            this.chartStats_TLA.Series["Toyota"]["PointWidth"] = "1";
            this.chartStats_TLA.Series["Toyota"].Points.AddXY(0, averagePowerToyota);
            this.chartStats_TLA.Series["BMW"].Points.AddXY(1, averagePowerBMW);
            this.chartStats_TLA.Series["Mersedes"].Points.AddXY(2, averagePowerMersedes);
            this.chartStats_TLA.Series["Nissan"].Points.AddXY(3, averagePowerNissan);
            this.chartStats_TLA.Series["LADA"].Points.AddXY(4, averagePowerLADA);
            this.chartStats_TLA.Series["Ferrari"].Points.AddXY(5, averagePowerFerrari);





        }

        private void buttonGuide_Click(object sender, EventArgs e)
        {
            FormGuide formGuide = new FormGuide();
            formGuide.ShowDialog();
        }

        
    }
}
 

