using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ViKing.Engine;
using static AccManager.myProxy;
using static AccManager.Logg;
using static AccManager.openBrowser_Proxy;
using Timer = System.Windows.Forms.Timer;
using static AccManager.NickShaker;


namespace AccManager
{
    public partial class Form1 : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////             ///////////////////////////////////////////////////////////
        //////////////////////////////////////////////////   REGIONS   ////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////             /////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region UNUSED CODE

        void testDataSet()
        {
            // добавляем таблицу в dataset

            // создаем столбцы для таблицы Books
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки
            idColumn.ReadOnly = true;

            DataColumn emailFullColumn = new DataColumn("emailFull", typeof(string));
            DataColumn pureMailLoginColumn = new DataColumn("pureMailLogin", typeof(string));
            DataColumn domainColumn = new DataColumn("domain", typeof(string));
            DataColumn mailPasswordColumn = new DataColumn("mailPassword", typeof(string));
            DataColumn bnetPasswordColumn = new DataColumn("bnetPassword", typeof(string));
            DataColumn registrationIPColumn = new DataColumn("registrationIP", typeof(string));
            DataColumn lastIPColumn = new DataColumn("lastIP", typeof(string));
            DataColumn firstNameColumn = new DataColumn("firstName", typeof(string));
            DataColumn lastNameColumn = new DataColumn("lastName", typeof(string));
            // DataColumn URLed_firstNameColumn = new DataColumn("URLed_firstName", typeof(string));
            // DataColumn URLed_lasttNameColumn = new DataColumn("URLed_lasttName", typeof(string));
            DataColumn firstName_translitColumn = new DataColumn("firstName_translit", typeof(string));
            DataColumn lastName_translitColumn = new DataColumn("lastName_translit", typeof(string));
            DataColumn regDateColumn = new DataColumn("regDate", typeof(string));
            DataColumn birthDateColumn = new DataColumn("birthDate", typeof(string));
            DataColumn secretAnswerMailColumn = new DataColumn("secretMail", typeof(string));
            DataColumn secretAnswerBnetColumn = new DataColumn("secretBnet", typeof(string));
            DataColumn successfullyMailColumn = new DataColumn("succMail", typeof(bool));
            DataColumn successfullyBnetColumn = new DataColumn("succBnet", typeof(bool));
            DataColumn verifedColumn = new DataColumn("verifed", typeof(bool));
            DataColumn wow1 = new DataColumn("wow1", typeof(string));
            DataColumn wow1Info = new DataColumn("wow1Info", typeof(string));
            DataColumn wow2 = new DataColumn("wow2", typeof(string));
            DataColumn wow2Info = new DataColumn("wow2Info", typeof(string));
            DataColumn wow3 = new DataColumn("wow3", typeof(string));
            DataColumn wow3Info = new DataColumn("wow3Info", typeof(string));
            DataColumn wow4 = new DataColumn("wow4", typeof(string));
            DataColumn wow4Info = new DataColumn("wow4Info", typeof(string));
            DataColumn wow5 = new DataColumn("wow5", typeof(string));
            DataColumn wow5Info = new DataColumn("wow5Info", typeof(string));
            DataColumn wow6 = new DataColumn("wow6", typeof(string));
            DataColumn wow6Info = new DataColumn("wow6Info", typeof(string));
            DataColumn wow7 = new DataColumn("wow7", typeof(string));
            DataColumn wow7Info = new DataColumn("wow7Info", typeof(string));
            DataColumn wow8 = new DataColumn("wow8", typeof(string));
            DataColumn wow8Info = new DataColumn("wow8Info", typeof(string));

            All.Clear();

            All.Columns.Add(idColumn);
            All.Columns.Add(emailFullColumn);
            All.Columns.Add(pureMailLoginColumn);
            All.Columns.Add(domainColumn);
            All.Columns.Add(mailPasswordColumn);
            All.Columns.Add(bnetPasswordColumn);
            All.Columns.Add(registrationIPColumn);
            All.Columns.Add(lastIPColumn);
            All.Columns.Add(firstNameColumn);
            All.Columns.Add(lastNameColumn);
            //  All.Columns.Add(URLed_firstNameColumn);
            //  All.Columns.Add(URLed_lasttNameColumn);
            All.Columns.Add(firstName_translitColumn);
            All.Columns.Add(lastName_translitColumn);
            All.Columns.Add(regDateColumn);
            All.Columns.Add(birthDateColumn);
            All.Columns.Add(secretAnswerMailColumn);
            All.Columns.Add(secretAnswerBnetColumn);
            All.Columns.Add(successfullyMailColumn);
            All.Columns.Add(successfullyBnetColumn);
            All.Columns.Add(verifedColumn);
            All.Columns.Add(wow1);
            All.Columns.Add(wow1Info);
            All.Columns.Add(wow2);
            All.Columns.Add(wow2Info);
            All.Columns.Add(wow3);
            All.Columns.Add(wow3Info);
            All.Columns.Add(wow4);
            All.Columns.Add(wow4Info);
            All.Columns.Add(wow5);
            All.Columns.Add(wow5Info);
            All.Columns.Add(wow6);
            All.Columns.Add(wow6Info);
            All.Columns.Add(wow7);
            All.Columns.Add(wow7Info);
            All.Columns.Add(wow8);
            All.Columns.Add(wow8Info);
            // определяем первичный ключ таблицы books
            // All.PrimaryKey = new DataColumn[] { All.Columns["Id"] };
            All.Rows.Add(null, "Контрольный", "акк", "нужен", "для", "целостности", "таблицы", "192.168.0.1",
                "КОНТРОЛЬНЫЙ", "АКК", "Kontrolniy", "Acc",
                new DateTime(2018, 11, 1), new DateTime(1970, 1, 1), "300004", "vaz", true, true, true,
                "ban", "wow1; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 80 lvl",
                "ban", "wow2; 2015-22-mar; 2011-11-jan; Kazzak; Heas; 0k; 80 lvl",
                "expired", "wow3; 2015-22-mar; 2011-11-jan; Kazzak; Dsaw; 0k; 80 lvl",
                "ban", "wow4; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 80 lvl",
                "active", "wow5; 2015-22-mar; 2011-11-jan; Kazzak; Dasss; 0k; 100 lvl",
                "ban", "wow6; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 90 lvl",
                "susp hard", "wow7; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 100 lvl",
                "trial", "wow8; 2015-22-mar; 2011-11-jan; Kazzak; Afgw; 0k; 20 lvl");
            /*  All.Rows.Add(null, "", "", "kk.l", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "", "Кис", "@!%!", "@)%(", "Vукфa", "",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "dildo", "42", true, true, false,
                  "", "wow1; 22 mar; 11 jan; Kazzak; Discourteous; 39k; 90 lvl");
              All.Rows.Add(null, "sdsag@kk.l", "sdsag", "kk.l", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "Валя", "Кис", "@!%!", "@)%(", "Valya", "Kis",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "dildo", "42", true, true, false,
                  "active", "wow1; 22 mar; 11 jan; Kazzak; Discourteous; 39k; 90 lvl");
              All.Rows.Add(null, "sdsewhbaag@kk.l", "sdsewhbaag", "kk.l", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "Валя", "Кис", "@!%!", "@)%(", "Valya", "Kis",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "sdaw", "42", true, true, false,
                  "active", " 22 mar 11 jan Kazzak Discourteous 39k 90 lvl");
              All.Rows.Add(null, "awawgaw@kk.l", "awawgaw", "kk.l", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "Kolya", "Кис", "@!%!", "@)%(", "egasg", "wa2f",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "sss", "42", true, true, false, null, null, null, null, null, null,
                  "ban", "wow4 22 mar 11 jan Kazzak Discourteous 39k 90 lvl");
              All.Rows.Add(null, "w3fqc@kk.l", "w3fqc", "kk.l", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "Валя", "Кис", "@!%!", "@)%(", "aawg", "Kegis",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "diaafaldo", "42", true, true, false, null, null,
                  "active", $"wow2 {DateTime.Now.ToString("yyyy-M-dd")} 11 jan Kazzak Discourteous 39k 90 lvl");
              All.Rows.Add(null, "QWs122ag@kk.l", "QWs122ag", "nn.su", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "Misha", "Mua", "@!%!", "@)%(", "Valya", "Kis",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "dildo", "42", true, true, false,
                  "susp lite", "wow1; 22 mar; 11 jan; Kazzak; pidr; 133; 110; stats");
              All.Rows.Add(null, "122s122ag@kk.l", "122s122ag", "nQQ.su", "qwer1234", "bnetQWER1234", "192.168.0.1", "192.168.0.1",
                  "ssag", "Киegс", "@!%!", "@)%(", "Valya", "Kis",
                  new DateTime(2016, 5, 13), new DateTime(1990, 3, 8), "dildo", "42", true, true, false,
                  "", "wow1; 22 mar; 11 jan; Kazzak; pidr; 749k; 100lvl; sych");

              All.Rows[2]["wow6"] = "susp lite";
              All.Rows[2]["wow6Info"] = "wow6;22 mar; 11 jan; Горда; Сыч; 6k; 100 lvl; gey";
              All.Rows[3]["wow4"] = "ban";
              All.Rows[3]["wow4Info"] = "22 mar 11 jan Kazzak Discourteous 39k 90 lvl";*/

            //  var gg = All.DataSet.Tables[0].Rows[0]["wow2"];
            All.WriteXmlSchema(@"D:\AccManager\schema1.xml");
            All.WriteXml(@"D:\AccManager\AccData1.xml");//сохраняем
            //All.WriteXml($@"D:\AccManager\Backups\AccData{DateTime.Now.ToString("yyyy-MM-dd HH.mm")}.xml");//сохраняем
            //dataSet.WriteXml(@"D:\AccData_OnOpen.xml");
        }

        #endregion

        #region EVENTS_etc


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            scrollDown();
        }

        private void textBox17_DoubleClick(object sender, EventArgs e)
        {
            textBox17.SelectAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LogCLEAR();
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Find(sender, e);
            }
        }

        private void textBox9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime expDate = DateTime.Now.AddMonths(1);
            textBox9.Text = (expDate.ToString("yyyy-M-d"));
        }

        private void textBox10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime expDate = DateTime.Now;
            textBox10.Text = (expDate.ToString("yyyy-M-d"));
        }

        private void table_MouseEnter(object sender, EventArgs e)
        {
            table_MouseWheel(sender, null);
            // _SelectedTable.FirstDisplayedScrollingRowIndex = _SelectedTable.FirstDisplayedScrollingRowIndex + 1;
            //_SelectedTable.Scroll()
        }

        private void table_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            /*int numberOfPixelsToMove = numberOfTextLinesToMove * fontSize;

            if (numberOfPixelsToMove != 0)
            {
                System.Drawing.Drawing2D.Matrix translateMatrix = new System.Drawing.Drawing2D.Matrix();
                translateMatrix.Translate(0, numberOfPixelsToMove);
                mousePath.Transform(translateMatrix);
            }
            panel1.Invalidate();*/
            _SelectedTable.FirstDisplayedScrollingRowIndex = _SelectedTable.FirstDisplayedScrollingRowIndex - numberOfTextLinesToMove;
            //_SelectedTable.Scroll()
        }


        private void dateGridView_Active_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView_Active.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0)
                {
                    dataGridView_Active.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Selected = true;
                    dataGridView_Active.ClearSelection();
                    dataGridView_Active.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView_Active, e.Location);
                }
            }
        }

        private void dateGridView_All_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView_All.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0)
                {
                    dataGridView_All.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Selected = true;
                    dataGridView_All.ClearSelection();
                    dataGridView_All.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip2.Show(dataGridView_All, e.Location);
                }
            }
        }


        private void dataGridView_Regged_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView_Regged.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0)
                {
                    dataGridView_Regged.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Selected = true;
                    dataGridView_Regged.ClearSelection();
                    dataGridView_Regged.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip2.Show(dataGridView_Regged, e.Location);
                }
            }
        }

        private void dataGridView_All_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  Log($"Column index = {_SelectedTable.SelectedCells[0].ColumnIndex.ToString()}\tColumn name = {_SelectedTable.Columns[x].Name.ToString()}");
            try
            {
                try
                {
                    string vov = _SelectedTable.Columns[x].Name.ToString();
                    string vov1 = vov.Substring(0, 4);

                    if (lastResultString != textBox16.Text && x > 0 && y > 0 && vov == vov.Substring(0, 4))
                        showSaveDialog(x, y);
                }
                catch (Exception)
                {
                    //throw;
                }

                Regex regex = new Regex(@"(wow)\d$");
                clearWoWXpanel();

                x = dataGridView_All.SelectedCells[0].ColumnIndex;
                y = dataGridView_All.SelectedCells[0].RowIndex;
                //if (dataGridView_All.Columns[x].Name == @"(wow)\d")
                if (regex.IsMatch(dataGridView_All.Columns[x].Name) && !string.IsNullOrEmpty(dataGridView_All.SelectedCells[0].Value.ToString()))
                    fillWoWXTable(dataGridView_All.Rows[y].Cells[x].Value.ToString(), dataGridView_All.Rows[y].Cells[x + 1].Value.ToString());
                else
                {
                }
                /*
                if (!textBoxWoWx2.Text.Contains("wow"))
                {
                    textBoxWoWx2.Text = dataGridView_All.Columns[dataGridView_All.SelectedCells[0].ColumnIndex].Name.ToString();
                }
                */
                lastResultString = textBox16.Text;
            }
            catch (Exception)
            {

                //throw;
            }


        }

        private void dataGridView_Active_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    string vov = _SelectedTable.Columns[x].Name.ToString();
                    string vov1 = vov.Substring(0, 4);

                    if (lastResultString != textBox16.Text && x > 0 && y > 0 && vov == vov.Substring(0, 4))
                        showSaveDialog(x, y);
                }
                catch (Exception)
                {
                    //throw;
                }

                Regex regex = new Regex(@"(wow)\d$");
                clearWoWXpanel();

                x = dataGridView_Active.SelectedCells[0].ColumnIndex;
                y = dataGridView_Active.SelectedCells[0].RowIndex;
                //if (dataGridView_All.Columns[x].Name == @"(wow)\d")
                if (regex.IsMatch(dataGridView_Active.Columns[x].Name) && !string.IsNullOrEmpty(dataGridView_Active.SelectedCells[0].Value.ToString()))
                    fillWoWXTable(dataGridView_Active.Rows[y].Cells[x].Value.ToString(), dataGridView_Active.Rows[y].Cells[x + 1].Value.ToString());
                else
                {
                }
                //saveWoWxChanges(x, y);
                lastResultString = textBox16.Text;
            }
            catch (Exception)
            {

                //throw;
            }

        }


        private void dataGridView_Inactive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    string vov = _SelectedTable.Columns[x].Name.ToString();
                    string vov1 = vov.Substring(0, 4);

                    if (lastResultString != textBox16.Text && x > 0 && y > 0 && vov == vov.Substring(0, 4))
                        showSaveDialog(x, y);
                }
                catch (Exception)
                {
                    //throw;
                }
                Regex regex = new Regex(@"(wow)\d$");
                clearWoWXpanel();

                x = dataGridView_Inactive.SelectedCells[0].ColumnIndex;
                y = dataGridView_Inactive.SelectedCells[0].RowIndex;
                //if (dataGridView_All.Columns[x].Name == @"(wow)\d")
                if (regex.IsMatch(dataGridView_Inactive.Columns[x].Name) && !string.IsNullOrEmpty(dataGridView_Inactive.SelectedCells[0].Value.ToString()))
                    fillWoWXTable(dataGridView_Inactive.Rows[y].Cells[x].Value.ToString(), dataGridView_Inactive.Rows[y].Cells[x + 1].Value.ToString());
                else
                {
                }
                //saveWoWxChanges(x, y);
                lastResultString = textBox16.Text;
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void dataGridView_Regged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    string vov = _SelectedTable.Columns[x].Name.ToString();
                    string vov1 = vov.Substring(0, 4);

                    if (lastResultString != textBox16.Text && x > 0 && y > 0 && vov == vov.Substring(0, 4))
                        showSaveDialog(x, y);
                }
                catch (Exception)
                {
                    //throw;
                }
                Regex regex = new Regex(@"(wow)\d$");
                clearWoWXpanel();

                x = dataGridView_Regged.SelectedCells[0].ColumnIndex;
                y = dataGridView_Regged.SelectedCells[0].RowIndex;
                //if (dataGridView_All.Columns[x].Name == @"(wow)\d")
                if (regex.IsMatch(dataGridView_Regged.Columns[x].Name) && !string.IsNullOrEmpty(dataGridView_Regged.SelectedCells[0].Value.ToString()))
                    fillWoWXTable(dataGridView_Regged.Rows[y].Cells[x].Value.ToString(), dataGridView_Regged.Rows[y].Cells[x + 1].Value.ToString());
                else
                {
                }
                //saveWoWxChanges(x, y);
                lastResultString = textBox16.Text;
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Char.IsLower(textBox11.Text.First()))
                {
                    textBox11.Text = Char.ToUpper(textBox11.Text.First()) + textBox11.Text.Substring(1, textBox11.Text.Length - 1).ToLower().Replace("-a", "-A").Replace("-h", "-H").Replace("-а", "-А").Replace("-о", "-О");
                }
                if (Char.IsLower(textBox12.Text.First()))
                {
                    textBox12.Text = Char.ToUpper(textBox12.Text.First()) + textBox12.Text.Substring(1, textBox12.Text.Length - 1).ToLower();
                }
                

            }
            catch (Exception)
            {
                //throw;
            }
            try
            {
                textBox16.Text = comboBox1.SelectedItem.ToString() + "; " + textBoxWoWx2.Text + "; " + textBox9.Text + "; " + textBox10.Text + "; " + textBox11.Text + "; " + textBox12.Text + "; " + textBox13.Text + "; " + textBox14.Text + "; " + comboBox_CompName.Text + "; " + textBox15.Text;
                changedText = textBox16.Text;
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void скрытьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_Active.SelectedRows[0].Visible = false;
            }
            catch (Exception)
            {
                //   throw;
            }
        }


        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _SelectedTable.CurrentCell.Value = null;
            }
            catch (Exception)
            {
                //throw;
            }
        }


        private void dataGridView_Active_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_Inactive_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_Regged_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_All_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        void backupTableAll(object sender, EventArgs e)
        {
            All.WriteXml($@"D:\AccManager\Backups\AccData{DateTime.Now.ToString("yyyy-MM-dd HH.mm")}.xml");//сохраняем
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabAll)
            {
                _SelectedTable = dataGridView_All;
                if (dataGridView_All.Rows.Count >= 1)
                {
                    dataGridView_All.Rows[0].Cells[0].Selected = true;
                }
                theAll();
            }
            if (tabControl1.SelectedTab == tabActive)
            {
                _SelectedTable = dataGridView_Active;
                if (dataGridView_Active.Rows.Count >= 1)
                {
                    dataGridView_Active.Rows[0].Cells[0].Selected = true;
                }
                actives();
            }
            if (tabControl1.SelectedTab == tabInactive)
            {
                _SelectedTable = dataGridView_Inactive;
                if (dataGridView_Inactive.Rows.Count >= 1)
                {
                    dataGridView_Inactive.Rows[0].Cells[0].Selected = true;
                }
                inactives();
            }
            if (tabControl1.SelectedTab == tabRegged)
            {
                _SelectedTable = dataGridView_Regged;
                if (dataGridView_Regged.Rows.Count >= 1)
                {
                    dataGridView_Regged.Rows[0].Cells[0].Selected = true;
                }
                regged();
            }
            _SelectedTable.Columns[0].Width = 34;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            /*if (tabControl1.SelectedTab == tabAll)
            {
                _SelectedTable = dataGridView_All;
                if (dataGridView_All.Rows.Count >= 1)
                {
                    dataGridView_All.Rows[0].Cells[0].Selected = true;
                }
                theAll();
            }
            if (tabControl1.SelectedTab == tabActive)
            {
                _SelectedTable = dataGridView_Active;
                if (dataGridView_Active.Rows.Count >= 1)
                {
                    dataGridView_Active.Rows[0].Cells[0].Selected = true;
                }
                actives();
            }
            if (tabControl1.SelectedTab == tabInactive)
            {
                _SelectedTable = dataGridView_Inactive;
                if (dataGridView_Inactive.Rows.Count >= 1)
                {
                    dataGridView_Inactive.Rows[0].Cells[0].Selected = true;
                }
                inactives();
            }
            if (tabControl1.SelectedTab == tabRegged)
            {
                _SelectedTable = dataGridView_Regged;
                if (dataGridView_Regged.Rows.Count >= 1)
                {
                    dataGridView_Regged.Rows[0].Cells[0].Selected = true;
                }
                regged();
            }
            _SelectedTable.Columns[0].Width = 20;*/
        }

        private void button_rand_name_Click(object sender, EventArgs e)
        {
            string server = textBox11.Text;
            server = Regex.Match(server, @"(\w+\s*\w*)-*\w*").Groups[1].Value;
            textBox12.Text = GetRandomNick_RU(server);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////             ///////////////////////////////////////////////////////////
        //////////////////////////////////////////////////   REGIONS   ////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////             /////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            //    dataGridView_Active.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgv4EditingControlShowing);
            // label1.Text = "Маска для инфы:\r\n active; wow1; 2016-06-06; 2015-3-11; Сервер; Ник; 99k; 93lvl; доп.ифно";
            Logg.richTB = richTextBox1;
        }
        Timer t1 = new Timer();
        List<myProxy> proxyList = new List<myProxy>();
        private DataGridView _SelectedTable;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                All.Clear();
                All.ReadXmlSchema(@"D:\AccManager\Schema.xml");
                All.ReadXml(@"D:\AccManager\AccData.xml");
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                открытьtoolStripButton1_Click(sender, e);
                //throw;
            }

            //string text = File.ReadAllText(@"D:\AccManager\proxx.txt");
            //rich_ProxyList.Text = text;


            button_refresh_list2_Click(sender, e);

            // List<string> proxList = new List<string>();

            t1.Interval = 300000;
            t1.Tick += backupTableAll;// new EventHandler(this.button_save_wowx_Click);
            t1.Start();

            tabControl1.SelectedTab = tabAll;
            // dataGridView_All.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_All.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_All.MultiSelect = false;
            // dataGridView_Active.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_Active.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_Active.MultiSelect = false;
            // dataGridView_Inactive.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_Inactive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_Inactive.MultiSelect = false;
            // dataGridView_Regged.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView_Regged.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_Regged.MultiSelect = false;
            //Refresh();
        }


        //   DataSet dataSet = new DataSet("Accounts");
        DataTable All = new DataTable("All");

        private string lastResultString = "";
        private string changedText = "";

        private void button1_Click(object sender, EventArgs e)
        {

            //All.Columns["verifed"].DataType = System.Type.GetType("System.Boolean");
            //   var seectall =  dataGridView_Active.SelectAll();
            //   dataGridView_All.Rows[0].Cells[0].Selected = true;
        }

        List<string> columnsWoWX = new List<string>() { "wow1", "wow2", "wow3", "wow4", "wow5", "wow6", "wow7", "wow8" };

        void theAll()
        {
            //////////////////////////          ALL            /////////////////////////////////////////////////////
            /// 
            //dataGridView_All.Margin = new Padding(10);
            dataGridView_All.DataSource = All;

            dataGridView_All.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView_All.Columns["firstName_translit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView_All.Columns["lastName_translit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView_All.Columns["firstName_translit"].Width = 45;
            dataGridView_All.Columns["lastName_translit"].Width = 45;
            dataGridView_All.Columns[1].Frozen = true;

            dataGridView_All.Rows[0].DefaultCellStyle.BackColor = Color.SlateGray;
        }

        void actives()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////          ACTIVE            /////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            dataGridView_Active.DataSource = All;
            dataGridView_Active.ClearSelection();
            dataGridView_Active.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            foreach (DataGridViewColumn column in dataGridView_Active.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (!dataGridView_Active.Columns.Contains("endSoonest"))
            {
                DataGridViewColumn endSoonest = new DataGridViewColumn(new DataGridViewTextBoxCell());
                endSoonest.Name = "endSoonest";
                endSoonest.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView_Active.Columns.Add(endSoonest);


            }

            //убираем лишнее
            var columnsNamesForHideInActives = new List<string>() { "pureMailLogin", "domain", "registrationIP", "firstName_translit", "lastName_translit",
                "regDate", "birthDate", "secretMail", "succMail", "succBnet", "verifed", "wow1Info" , "wow2Info", "wow3Info", "wow4Info", "wow5Info", "wow6Info", "wow7Info", "wow8Info" };

            foreach (var nm in columnsNamesForHideInActives)
            {
                dataGridView_Active.Columns[nm].Visible = false;
            }

            /////////////////////       выбор строк для показа      /////////////////////

            for (int i = 0; i < dataGridView_Active.RowCount - 1; i++)
            {
                bool activeflag = false;
                DateTime soonestEndDate = new DateTime(2050, 12, 31);
                string soonestEndWoWX = "";

                foreach (var wowx in columnsWoWX)
                {
                    try
                    {   //если присутствует хоть один activate или короткий бан, то добавляем акк в активные
                        if (All.Rows[i]["emailFull"].ToString() == "Контрольный")
                        {
                            activeflag = true;
                            dataGridView_Active.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                            break;
                        }
                        if (All.Rows[i][wowx].ToString() == "active" || All.Rows[i][wowx].ToString() == "susp lite")
                        {
                            activeflag = true;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }

                var statusList = new List<string>() { "active", "expired", "susp lite", "susp hard", "trial" };

                if (activeflag)
                {   //если в прошлом цикле определили, что есть активный акк, то проставляем для каждой записи вов статус
                    foreach (var wowx in columnsWoWX)
                    {
                        try
                        {
                            //  var strings1 = All.Rows[i][wowx];
                            if (All.Rows[i]["emailFull"].ToString() != "Контрольный" && !string.IsNullOrEmpty(All.Rows[i][wowx].ToString()) && statusList.Contains(All.Rows[i][wowx].ToString()))
                            {
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                                comboCell.Items.Add("");
                                comboCell.Items.Add("active");
                                comboCell.Items.Add("expired");
                                comboCell.Items.Add("susp lite");
                                comboCell.Items.Add("susp hard");
                                comboCell.Items.Add("ban");
                                comboCell.Items.Add("trial");
                                comboCell.Items.Add("??????");
                                comboCell.Style.Padding = new Padding(2);
                                dataGridView_Active.Rows[i].Cells[wowx] = comboCell;
                                // dataGridView_Active.Columns[wowx];
                                if (All.Rows[i][wowx].ToString() == comboCell.Items[1].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[1];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[2].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[2];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[3].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[3];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[4].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[4];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[5].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[5];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[6].ToString()) dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[6];
                                else dataGridView_Active.Rows[i].Cells[wowx].Value = comboCell.Items[7];

                                if (dataGridView_Active.Rows[i].Cells[wowx].Value == "active")
                                {
                                    dataGridView_Active.Rows[i].Cells[wowx].Style.BackColor = Color.GreenYellow;
                                }
                                else if (dataGridView_Active.Rows[i].Cells[wowx].Value == "susp lite")
                                {
                                    dataGridView_Active.Rows[i].Cells[wowx].Style.BackColor = Color.Orange;
                                }

                                if (!string.IsNullOrEmpty(All.Rows[i][wowx].ToString()) && (All.Rows[i][wowx].ToString() == "active" || All.Rows[i][wowx].ToString() == "susp lite"))
                                {
                                    try
                                    {
                                        string[] stringSeparators = new string[] { "; " };
                                        string egagw = All.Rows[i][wowx + "Info"].ToString();
                                        string dt = egagw.Split(stringSeparators, StringSplitOptions.None)[1];
                                        DateTime expTime = DateTime.ParseExact(dt, "yyyy-M-d", CultureInfo.InvariantCulture);
                                        if (expTime <= DateTime.Now)
                                        {
                                            MessageBox.Show($"in row #{All.Rows[i]["id"].ToString()} [{All.Rows[i]["emailFull"].ToString()} ; {wowx}] - \r\nЗакончилась оплата или хз че \r\n обновите данные");
                                            Log($"in row #{All.Rows[i]["id"].ToString()} [{All.Rows[i]["emailFull"].ToString()} ; {wowx}] - Закончилась оплата или хз че??   |   обновите дату или поменяйте статус");
                                        }
                                        else if (expTime - DateTime.Now <= TimeSpan.FromDays(5))
                                        {
                                            Log($"in row #{All.Rows[i]["id"].ToString()} [{All.Rows[i]["emailFull"].ToString()} ; {wowx}] - оплата закончится через {(expTime - DateTime.Now).Days} дней");
                                        }
                                        if (expTime <= soonestEndDate)
                                        {
                                            dataGridView_Active.Rows[i].Cells["endSoonest"].Value = dt;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //MessageBox.Show($"in row #{All.Rows[i]["id"].ToString()} [{All.Rows[i]["emailFull"].ToString()} ; {wowx}] - {ex.Message}");
                                        Log($"in row #{All.Rows[i]["id"].ToString()} [{All.Rows[i]["emailFull"].ToString()} ; {wowx}] - {ex.Message}");
                                        //throw;
                                    }

                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                            // throw;
                        }
                    }
                }
                else
                {   //если в строке нет активных записей, то скрываем ее
                    try
                    {
                        dataGridView_Active.SelectNextControl(this.ActiveControl, true, true, true, true);
                        dataGridView_Active.ClearSelection();
                        dataGridView_Active.Rows[i].Visible = false;

                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }
            }
            LogEmptyRow();
        }

        void inactives()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////          INACTIVE          /////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            dataGridView_Inactive.DataSource = All;
            dataGridView_Inactive.ClearSelection();
            dataGridView_Inactive.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            foreach (DataGridViewColumn column in dataGridView_Inactive.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var columnsNamesForHideInInactives = new List<string>() { "pureMailLogin", "domain", "registrationIP", "firstName_translit", "lastName_translit",
                "birthDate", "succMail", "succBnet", "verifed", "wow1Info" , "wow2Info", "wow3Info", "wow4Info", "wow5Info", "wow6Info", "wow7Info", "wow8Info" };

            foreach (var nm in columnsNamesForHideInInactives)
            {
                dataGridView_Inactive.Columns[nm].Visible = false;
            }

            /////////////////////       выбор строк для показа      /////////////////////
            //var columnsWoWX = new List<string>() { "wow1", "wow2", "wow3", "wow4", "wow5", "wow6", "wow7", "wow8" };
            for (int i = 0; i < dataGridView_Inactive.RowCount - 1; i++)
            {
                bool activeflag = true;

                foreach (var wowx in columnsWoWX)
                {
                    try
                    {   //если присутствует хоть один activate или короткий бан, то добавляем акк в активные
                        if (All.Rows[i]["emailFull"].ToString() == "Контрольный")
                        {
                            activeflag = true;
                            dataGridView_Inactive.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                            break;
                        }
                        if (string.IsNullOrEmpty(All.Rows[i]["wow1"].ToString()) || All.Rows[i]["wow1"].ToString() == "trial")
                        {//если в первой ячейке нет акка или он trial, то акк не выводить

                            activeflag = false;
                            break;
                        }
                        if (All.Rows[i][wowx].ToString() == "active" || All.Rows[i][wowx].ToString() == "susp lite")
                        {
                            activeflag = false;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }

                if (activeflag)
                {   //если в прошлом цикле определили, что есть активный акк, то проставляем для каждой записи вов статус
                    foreach (var wowx in columnsWoWX)
                    {
                        try
                        {
                            //  var strings1 = All.Rows[i][wowx];
                            if (!string.IsNullOrEmpty(All.Rows[i][wowx].ToString()))
                            {
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                                comboCell.Items.Add("");
                                comboCell.Items.Add("active");
                                comboCell.Items.Add("expired");
                                comboCell.Items.Add("susp lite");
                                comboCell.Items.Add("susp hard");
                                comboCell.Items.Add("ban");
                                comboCell.Items.Add("trial");
                                comboCell.Items.Add("??????");

                                dataGridView_Inactive.Rows[i].Cells[wowx] = comboCell;
                                if (All.Rows[i][wowx].ToString() == comboCell.Items[0].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[0];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[1].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[1];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[2].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[2];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[3].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[3];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[4].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[4];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[5].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[5];
                                else if (All.Rows[i][wowx].ToString() == comboCell.Items[6].ToString()) dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[6];
                                else dataGridView_Inactive.Rows[i].Cells[wowx].Value = comboCell.Items[7];
                            }

                        }
                        catch (Exception)
                        {
                            // throw;
                        }
                    }
                }
                else
                {   //если в строке нет активных записей, то скрываем ее
                    try
                    {
                        dataGridView_Inactive.ClearSelection();
                        dataGridView_Inactive.Rows[i].Visible = false;

                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }
            }
        }

        void regged()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////           REGGED           /////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            dataGridView_Regged.DataSource = All;
            dataGridView_Regged.ClearSelection();
            dataGridView_Regged.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            foreach (DataGridViewColumn column in dataGridView_Regged.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var columnsNamesForHideInRegged = new List<string>() { "pureMailLogin", "domain", "registrationIP", "firstName_translit", "lastName_translit",
                   "birthDate", "wow1Info" , "wow2Info", "wow3Info", "wow4Info", "wow5Info", "wow6Info", "wow7Info", "wow8Info" };

            foreach (var nm in columnsNamesForHideInRegged)
            {
                dataGridView_Regged.Columns[nm].Visible = false;
            }

            /////////////////////       выбор строк для показа      /////////////////////
            //var columnsWoWX = new List<string>() { "wow1", "wow2", "wow3", "wow4", "wow5", "wow6", "wow7", "wow8" };
            for (int i = 1; i < dataGridView_Regged.RowCount - 1; i++)
            {
                //  bool activeflag = true;

                try
                {   //если у акка есть статус, кроме пустого и триала, то скрываем его
                    /* if (All.Rows[i]["emailFull"].ToString() == "Контрольный")
                     {
                         dataGridView_Regged.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                        // break;
                     }
                    */
                    dataGridView_Regged.Rows[0].DefaultCellStyle.BackColor = Color.SlateGray;

                    if (All.Rows[i]["wow1"].ToString() == "trial" || All.Rows[i]["wow1"].ToString() == "")
                    {
                    }
                    else
                    {
                        try
                        {
                            dataGridView_Regged.ClearSelection();
                            dataGridView_Regged.Rows[i].Visible = false;
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        //break;
                    }
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void button_save_wowx_Click(object sender, EventArgs e)
        {
            saveWoWxChanges(x, y);
        }

        void saveWoWxChanges(int x, int y)  //координаты последнего выбранного
        {
            //Regex regexxx = new Regex(@"(wow)\d");
            //Match mat = regexxx.Match(_SelectedTable.Columns[_SelectedTable.SelectedCells[0].ColumnIndex].Name.ToString());
            string vov = _SelectedTable.Columns[x].Name.ToString();

            if (x > 0 && y > 0 && vov == vov.Substring(0, 4))
            {
                //при перемещении курсора "сохранить данные вов 1-8?
                //  if (this.lastResultString != "" && textBox16.Text != lastResultString)
                string[] stringSeparators = new string[] { "; " };
                string status = textBox16.Text.Split(stringSeparators, StringSplitOptions.None).First();
                All.Rows[y][x] = status;
                Regex regex = new Regex($@"({All.Columns[x].ColumnName}).*");
                Match match = regex.Match(textBox16.Text);
                if (match == Match.Empty)
                {
                    //MessageBox.Show("Укажите запись wow-");
                    textBoxWoWx2.Text = All.Columns[x].ColumnName;
                    match = regex.Match(textBox16.Text);
                }
                All.Rows[y][x + 1] = match;
                lastResultString = textBox16.Text;
                fillWoWXTable(status, match.Value.ToString());
            }
        }

        void showSaveDialog(int x, int y)
        {
            if (/*this.lastResultString != "" && */textBox16.Text != lastResultString)
            {
                DialogResult result =
                    MessageBox.Show(
                        $"Сохранить изменения в аккаунте?\r\n Было: {lastResultString}\r\nСтало: {textBox16.Text}",
                        "Запрос на изменеие данных",
                        MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    saveWoWxChanges(x, y);
                }
                else if (result == DialogResult.No)
                {
                    //return false;
                    //...
                }
            }
        }

        int x;
        int y;

        void clearWoWXpanel()
        {
            comboBox1.SelectedItem = "";
            textBoxWoWx2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            comboBox_CompName.SelectedItem = "";
        }

        void fillWoWXTable(string status, string info)
        {
            if (string.IsNullOrWhiteSpace(status) || string.IsNullOrEmpty(status))
            {
                comboBox1.SelectedItem = "";
                return;
            }
            else if (status == "active") comboBox1.SelectedItem = "active";
            else if (status == "expired") comboBox1.SelectedItem = "expired";
            else if (status == "susp lite") comboBox1.SelectedItem = "susp lite";
            else if (status == "susp hard") comboBox1.SelectedItem = "susp hard";
            else if (status == "ban") comboBox1.SelectedItem = "ban";
            else if (status == "trial") comboBox1.SelectedItem = "trial";
            else comboBox1.SelectedItem = "???????";
            try
            {
                string[] stringSeparators = new string[] { "; " };
                string[] str = info.Split(stringSeparators, StringSplitOptions.None);
                textBoxWoWx2.Text = str[0];
                textBox9.Text = str[1];
                textBox10.Text = str[2];
                textBox11.Text = str[3];
                textBox12.Text = str[4];
                textBox13.Text = str[5];
                textBox14.Text = str[6];
                comboBox_CompName.Text = str[7];
                textBox15.Text = str[8];
            }
            catch (Exception)
            {
                //  throw;
            }
        }


        private void openBrowser_button_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>() { "chrome", "Chrome", "chrome.exe", "chrome32", "Chrome32", "chrome32.exe", "chrome64", "Chrome64", "chrome64.exe" };
            Process[] pr2 = Process.GetProcesses();
            for (int i = 0; i < pr2.Length; i++)
            {
                if (names.Contains(pr2[i].ProcessName))
                {
                    MessageBox.Show("Браузер уже открыт!");
                    return;
                }
            }

            if (string.IsNullOrEmpty(_SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString()))
            {
                MessageBox.Show("нет IP!");
                return;
            }

            string Proxifier_Settings_File = $@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx";
            XDocument doc = XDocument.Load(Proxifier_Settings_File);
            /*
            string wgew;
            if (_SelectedTable.SelectedCells[0].RowIndex == 0)
            {
                wgew = _SelectedTable.SelectedRows[0].Cells["emailfull"].Value.ToString();
            }
            var thrw = _SelectedTable.SelectedRows[0];//.Cells["emailFull"].Value.ToString();
            */

            List<string> proxArr = new List<string>();// = File.ReadAllLines(@"D:\AccManager\proxx.txt");
            XDocument proxdoc = XDocument.Load(@"D:\VM\Dropbox\AccManager\proxyList.xml");
            foreach (var prox in proxdoc.Root.Elements("proxy"))
            {
                proxArr.Add(prox.Attribute("Adress").Value.ToString());
            }


            //var lastop = _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString();

            string lastIP_str = _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString();
            string lastIP = "";
            if (lastIP_str != "main")
            {
                lastIP = Regex.Matches(lastIP_str, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")[0].Value;
            }


            if (_SelectedTable.SelectedCells[0].RowIndex <= 0 && _SelectedTable.SelectedCells[0].ColumnIndex <= 0)
            {
                MessageBox.Show(@"Выберите аккаунт");
            }
            else if (lastIP_str == "main")
            {
                System.Threading.Thread MyThread1 =
                 new System.Threading.Thread(delegate ()
                 {
                     openChrome_mainIP(doc, _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString(), Proxifier_Settings_File);
                 });
                MyThread1.Start();
            }
            else if (!proxArr.Contains(lastIP))
            {
                MessageBox.Show("такого прокси нет в списке");
            }
            else
            {
                var sel = proxyList.Select(a => a.Adress == _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString());
                var selectedProxy = proxyList.First(a => a.Adress == lastIP);
                System.Threading.Thread MyThread1 =
                 new System.Threading.Thread(delegate ()
                 {
                     openChrome_viaProxy(doc, _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString(), selectedProxy, Proxifier_Settings_File);
                 });
                MyThread1.Start();
            }



            // openChrome_viaProxy(doc, _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString(),
            //     _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString(), Proxifier_Settings_File);    // (doc, emailFull, proxy(string), proxyfierProfile_path)
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {

                string path = @"D:\AccManager\NewAccounts\"; // this is the path that you are checking.
                if (Directory.Exists(path))
                {
                    openFileDialog.InitialDirectory = path;
                }
                else
                {
                    openFileDialog.InitialDirectory = @"C:\";
                }

                openFileDialog.Filter = "(Файл с аккаунтами *.xml) | *.xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable newAccs = new DataTable("All");
                    newAccs.Clear();
                    newAccs.ReadXmlSchema(@"D:\AccManager\Schema.xml");
                    newAccs.ReadXml(openFileDialog.FileName);

                    for (int i = 0; i < newAccs.Rows.Count; i++)
                    {
                        if (All.Select($"emailFull = '{newAccs.Rows[i]["emailFull"].ToString()}'").Length == 0)//    All.Columns["emailFull"])
                        {

                            newAccs.Rows[i]["lastIP"] = newAccs.Rows[i]["registrationIP"];          //  переносим новые акки в главную таблицу. 
                            newAccs.Columns["id"].ReadOnly = false;                                 //  нужно снять readonly чтобы изменить ид на нужный
                            newAccs.Rows[i]["id"] = (int)All.Rows[All.Rows.Count - 1]["id"] + 1;
                            All.ImportRow(newAccs.Rows[i]);                                         //  и только потом перенести в главную таблицу
                                                                                                    // All.Rows.Add(new DataRow(newAccs.Rows[i]));
                        }
                        else
                        {
                            Log("акк уже есть в списке");
                        }
                    }
                    newAccs.Dispose();

                    /*   All.Rows.Add(null, "Контрольный", "акк", "нужен", "для", "целостности", "таблицы", "192.168.0.1",
                   "КОНТРОЛЬНЫЙ", "АКК", "!!!!!", "!!!!!_!", "Kontrolniy", "Acc",
                   new DateTime(2018, 11, 1), new DateTime(1970, 1, 1), "300004", "vaz", true, true, true,
                   "ban", "wow1; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 80 lvl",
                   "ban", "wow2; 2015-22-mar; 2011-11-jan; Kazzak; Heas; 0k; 80 lvl",
                   "expired", "wow3; 2015-22-mar; 2011-11-jan; Kazzak; Dsaw; 0k; 80 lvl",
                   "ban", "wow4; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 80 lvl",
                   "active", "wow5; 2015-22-mar; 2011-11-jan; Kazzak; Dasss; 0k; 100 lvl",
                   "ban", "wow6; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 90 lvl",
                   "susp hard", "wow7; 2015-22-mar; 2011-11-jan; Kazzak; Dss; 0k; 100 lvl",
                   "trial", "wow8; 2015-22-mar; 2011-11-jan; Kazzak; Afgw; 0k; 20 lvl");*/
                }
                Log("акки добавлены.");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            string[] textFromFile = File.ReadAllLines(@"C:\Users\nnn\AppData\Roaming\Thunderbird\Profiles\uhdcnwyd.default\prefs.js");
            List<string> neededStrings = new List<string>();
            foreach (var str in textFromFile)
            {
                if (str.Contains("user_pref(\"mail.identity."))
                    neededStrings.Add(str);
            }


            string mail = "any.fom1996@yandex.ru";
            var findstr = $".useremail\", \"{mail}\"";
            int sum = 0;
            List<string> forWriteList = new List<string>();

            foreach (DataRow row in All.Rows)
            {

                mail = row["emailFull"].ToString();
                if (mail != "Контрольный")
                {
                    findstr = $".useremail\", \"{mail}\"";
                    //var subj = row["emailFull"].ToString();
                    // var myRegex = new Regex($@"\.*{findstr}\.*");
                    // var subj = "user_pref(\"mail.identity.id2.sig_bottom\", true);";
                    if (neededStrings.Any(s => Regex.IsMatch(s, $@"\.*{findstr}\.*")))
                        sum++;
                    else
                    {
                        forWriteList.Add($"{row["emailFull"].ToString()}:{row["mailPassword"].ToString()}");
                    }
                }
            }
            File.WriteAllLines(@"D:\AccManager\forThnderbird.txt", forWriteList);
            Log("файл создан.");
        }

        private void button_Find(object sender, EventArgs e)
        {
            // var cell = All.Select($"emailFull='{textBox18.Text}'").First();
            string neededText = textBox18.Text.ToLower();

            int startRow = 0;
            try
            {
                if (_SelectedTable.SelectedCells.Count>0 && _SelectedTable.SelectedCells[0].Value.ToString().ToLower().Contains(neededText))
                {
                    startRow = _SelectedTable.SelectedCells[0].RowIndex+1;
                    _SelectedTable.ClearSelection();
                    //_SelectedTable.Rows[startRow].Cells[_SelectedTable.SelectedCells[0].ColumnIndex].Selected = true;
                }
            }
            catch (Exception)
            {
                throw;
            }


            for (int i = startRow; i < _SelectedTable.RowCount; i++)
            {
                _SelectedTable.Rows[i].Selected = false;
                for (int j = 0; j < _SelectedTable.ColumnCount; j++)
                    if (_SelectedTable.Rows[i].Cells[j].Value != null)
                        if (_SelectedTable.Rows[i].Cells[j].Value.ToString().ToLower().Contains(neededText))    //поиск не учитывает регистр
                        {
                            try
                            {
                                if (_SelectedTable.Rows[i].Visible == false)
                                {
                                    Log("Cтрока скрыта в данной таблице");
                                    //MessageBox.Show("строка скрыта в данной таблице");
                                    break;
                                }
                                else
                                {
                                    _SelectedTable.FirstDisplayedScrollingRowIndex = i;
                                    //_SelectedTable.SelectedCells[0] = true;
                                    _SelectedTable.Rows[i].Cells[j].Selected = true;
                                   // Log(_SelectedTable.SelectedRows[0].Index+" "+_SelectedTable.SelectedColumns[0].Index);
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                Log(ex.Message);
                                //throw;
                            }

                        }
            }
            Log("Значения в данной таблице не найдено.");
        }

        private void получитьJsДляАвтНаBnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string js =
                $"var login = \"{_SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString()}\";\r\ndocument.getElementById(\"accountName\").value = login;\r\n" +
                $"var password = \"{_SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["bnetPassword"].Value.ToString()}\";\r\ndocument.getElementById(\"password\").value = password;";

            Clipboard.SetText(js);
        }


        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(listBox1.SelectedItems[0].ToString());
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(listBox2.SelectedItems[0].ToString());
            }
        }

        private void button_refresh_list2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            try
            {
                proxyList = LoadProxyList("D:\\VM\\Dropbox\\AccManager\\proxyList.xml");
                foreach (var prox in proxyList)
                {
                    listBox1.Items.Add(prox.Adress);
                    listBox2.Items.Add(prox.Adress);
                }
                //listBox1.Sorted = true;
                SaveProxyList(proxyList, $"D:\\AccManager\\Backups\\proxyList{DateTime.Now.ToString("yyyy-MM-dd HH.mm")}.xml");
            }
            catch (Exception)
            {
                //throw;
            }

            for (int i = 0; i < All.Rows.Count; i++)
            {
                foreach (var wowx in columnsWoWX)
                {
                    if (All.Rows[i][wowx].ToString() == "active" || All.Rows[i][wowx].ToString() == "susp lite")
                    {
                        try
                        {
                            var matches = Regex.Matches(All.Rows[i]["lastIP"].ToString(), @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                            foreach (var match in matches)
                            {
                                listBox2.Items.Remove(match.ToString());
                            }

                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        break;
                    }
                }
            }

            uint sum = 0;
            for (int i = 0; i < All.Rows.Count; i++)
            {
                foreach (var wowx in columnsWoWX)
                {
                    if (All.Rows[i]["emailFull"].ToString() != "Контрольный" && All.Rows[i][wowx].ToString() == "active" || All.Rows[i][wowx].ToString() == "susp lite")
                    {
                        sum++;
                    }
                }
            }
            label4.Text = $"Активно {sum.ToString()} учетных записей";
        }

        private void удалитьСтрокуСовсемToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Точно удалить строку?\r\n{dataGridView_All.Rows[dataGridView_All.SelectedCells[0].RowIndex].Cells[1].Value}",
                    "Запрос на удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (dataGridView_All.Rows[dataGridView_All.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString() == "Контрольный")
                    {
                        MessageBox.Show("Нельзя просто так взять и удалить\r\nКонтрольный аккаунт");
                    }
                    else
                    {
                        dataGridView_All.Rows.RemoveAt(dataGridView_All.SelectedCells[0].RowIndex);
                        Log("удалил строку");
                        //по индексу строки удаляем
                    }

                }
                //  dataGridView_Active.Rows.Remove(DataGridViewRow row); //удаляем по известной строке
            }
            catch (Exception)
            {
                //   throw;
            }
        }

        private void удалитьСтрокуСовсемToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Точно удалить строку?\r\n{dataGridView_Regged.Rows[dataGridView_Regged.SelectedCells[0].RowIndex].Cells[1].Value}",
                    "Запрос на удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (dataGridView_Regged.Rows[dataGridView_Regged.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString() == "Контрольный")
                    {
                        MessageBox.Show("Нельзя просто так взять и удалить\r\nКонтрольный аккаунт");
                    }
                    else
                    {
                        dataGridView_Regged.Rows.RemoveAt(dataGridView_Regged.SelectedCells[0].RowIndex);
                        Log("удалил строку");
                        //по индексу строки удаляем
                    }

                }
                //  dataGridView_Active.Rows.Remove(DataGridViewRow row); //удаляем по известной строке
            }
            catch (Exception)
            {
                //   throw;
            }
        }


        private void сохранитьtoolStripButton2_Click(object sender, EventArgs e)
        {
            // DataTable dssave = (DataTable)dataGridView_All.DataSource;
            // All.WriteXmlSchema(@"D:\AccManager\schema1.xml");
            All.WriteXml(@"D:\AccManager\AccData.xml");//сохраняем
            All.WriteXml($@"D:\AccManager\Backups\AccData{DateTime.Now.ToString("yyyy-MM-dd HH.mm")}.xml");//сохраняем
            dataGridView_All.ClearSelection();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            List<string> names = new List<string>() { "chrome", "Chrome", "chrome.exe", "chrome32", "Chrome32", "chrome32.exe", "chrome64", "Chrome64", "chrome64.exe" };
            Process[] pr2 = Process.GetProcesses();
            for (int i = 0; i < pr2.Length; i++)
            {
                if (names.Contains(pr2[i].ProcessName))
                {
                    MessageBox.Show("Сначала закройте браузер!");
                    e.Cancel = true;
                    return;
                }
            }

            if (dataGridView_All.Rows.Count >= 2)
            {
                DialogResult result = MessageBox.Show($"Сохранить изменения?", "Запрос на сохранение",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    сохранитьtoolStripButton2_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    // сохранитьtoolStripButton2_Click(sender, e);
                }
            }
        }


        private void открытьtoolStripButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {

                string path = @"D:\AccManager\"; // this is the path that you are checking.
                if (Directory.Exists(path))
                {
                    openFileDialog.InitialDirectory = path;
                }
                else
                {
                    openFileDialog.InitialDirectory = @"C:\";
                }

                openFileDialog.Filter = "(Файл с аккаунтами *.xml) | *.xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    All.Clear();
                    All.ReadXmlSchema(openFileDialog.FileName);
                    All.ReadXml(openFileDialog.FileName);
                }
            }
        }

        private void создатьСкриптДляToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://eu.battle.net/shop/ru/checkout/buy/2210043971000006457");
        }

        void createQuickSetingsFile(string emailFull, string wowx, string proxyIP, string password = "qwer1234", string nick = "", string realm = "", string region = "Auto")
        {
            string SettingsFolderPath = "";
            if (Directory.Exists($@"D:\"))
            {
                if (!Directory.Exists($@"D:\VM\"))
                {
                    Directory.CreateDirectory($@"D:\VM\");
                }
                if (!Directory.Exists($@"D:\VM\Dropbox"))
                {
                    Directory.CreateDirectory($@"D:\VM\Dropbox");
                }
                if (!Directory.Exists($@"C:\VM\Dropbox\AccManager"))
                {
                    Directory.CreateDirectory($@"C:\VM\Dropbox\AccManager");
                }
                if (!Directory.Exists($@"D:\VM\Dropbox\AccManager\QuickSettings"))
                {
                    Directory.CreateDirectory($@"D:\VM\Dropbox\AccManager\QuickSettings");
                }
                SettingsFolderPath = @"D:\VM\Dropbox\AccManager\QuickSettings";
            }
            else if (Directory.Exists($@"C:\"))
            {
                if (!Directory.Exists($@"C:\VM\"))
                {
                    Directory.CreateDirectory($@"C:\VM\");
                }
                if (!Directory.Exists($@"C:\VM\Dropbox"))
                {
                    Directory.CreateDirectory($@"C:\VM\Dropbox");
                }
                if (!Directory.Exists($@"C:\VM\Dropbox\AccManager"))
                {
                    Directory.CreateDirectory($@"C:\VM\Dropbox\AccManager");
                }
                if (!Directory.Exists($@"C:\VM\Dropbox\AccManager\QuickSettings"))
                {
                    Directory.CreateDirectory($@"C:\VM\Dropbox\AccManager\QuickSettings");
                }
                SettingsFolderPath = @"C:\VM\Dropbox\AccManager\QuickSettings";
            }
            else
            {
                MessageBox.Show("Не могу найти нужный диск D: / C:");
                return;
            }

            string settingsFilePath = $@"{SettingsFolderPath}\{emailFull}-{wowx}.xml";

            /*   if (!File.Exists(settingsFilePath))
               {
                   File.Delete(settingsFilePath);
               }

               Thread.Sleep(50);
            */

            // if (!File.Exists(settingsFilePath))
            {
                XDocument doc = new XDocument(new XElement("QuickSettings"));
                doc.Root.Add(new XElement("proxyIP", proxyIP));
                doc.Root.Add(new XElement("emailFull", emailFull));
                doc.Root.Add(new XElement("WoWX", wowx.Replace('w', 'W')));
                doc.Root.Add(new XElement("Password", password));
                doc.Root.Add(new XElement("Nick", nick));
                doc.Root.Add(new XElement("Realm", Regex.Match(realm, "(\\w+)").Groups[1]));

                doc.Save(settingsFilePath);
                Log($"QuickSettings для {emailFull} - {wowx} создан");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createQuickSetingsFile(_SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["emailFull"].Value.ToString(),
                textBoxWoWx2.Text, _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["lastIP"].Value.ToString(),
                _SelectedTable.Rows[_SelectedTable.SelectedCells[0].RowIndex].Cells["bnetPassword"].Value.ToString(), textBox12.Text, textBox11.Text);
        }

        
    }
}
