using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MTGCardChecker
{
    public partial class fStatistics : Form
    {
        public fStatistics(List<Card> deck)
        {
            InitializeComponent();
            fillPie(deck);
        }
        private void fillPie(List<Card> lData)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("Legend");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Verteilung";
            chart1.Legends[0].BorderColor = Color.Black;

            string seriesname = "MySeriesName";
            chart1.Series.Add(seriesname);
            chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            int lands = lData.Where(x => x.GetType().Name.Equals("LandCard")).Sum(x => x.amountInDeck);
            int creat = lData.Where(x => x.GetType().Name.Equals("CreatureCard")).Sum(x => x.amountInDeck);
            int inst = lData.Where(x => x.GetType().Name.Equals("InstantCard")).Sum(x => x.amountInDeck);
            int sorc = lData.Where(x => x.GetType().Name.Equals("SorceryCard")).Sum(x => x.amountInDeck);
            int entchant = lData.Where(x => x.GetType().Name.Equals("EntchantmentCard")).Sum(x => x.amountInDeck);
            int planewalker = lData.Where(x => x.GetType().Name.Equals("PlaneswalkerCard")).Sum(x => x.amountInDeck);

            if(lands > 0) chart1.Series[seriesname].Points.AddXY(lands + " Lands", lands);
            if (creat > 0) chart1.Series[seriesname].Points.AddXY(creat + " Creatures", creat);
            if (inst > 0) chart1.Series[seriesname].Points.AddXY(inst + " Instants", inst);
            if (sorc > 0) chart1.Series[seriesname].Points.AddXY(sorc + " Sorceries", sorc);
            if (entchant > 0) chart1.Series[seriesname].Points.AddXY(entchant + " Entchantments", entchant);
            if (planewalker > 0) chart1.Series[seriesname].Points.AddXY(planewalker + " Planewalkers", planewalker);           
        }
    }
}
