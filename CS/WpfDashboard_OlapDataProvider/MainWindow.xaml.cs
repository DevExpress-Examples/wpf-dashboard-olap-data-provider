using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using System.Windows;

namespace WpfDashboard_OlapDataProvider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dashboardControl1.Dashboard = CreateDashboard(); ;            
        }

        private Dashboard CreateDashboard()
        {
            Dashboard dBoard = new Dashboard();

            OlapConnectionParameters olapParams = new OlapConnectionParameters();
            olapParams.ConnectionString = @"provider=MSOLAP;
                                  data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;
                                  initial catalog=Adventure Works DW Standard Edition;
                                  cube name=Adventure Works;";

            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource(olapParams);
            dBoard.DataSources.Add(olapDataSource);

            CardDashboardItem cardItem = new CardDashboardItem();
            cardItem.DataSource = olapDataSource;
            cardItem.SeriesDimensions.Add(new Dimension("[Sales Territory].[Sales Territory Country].[Sales Territory Country]"));
            cardItem.SparklineArgument = new Dimension("[Date].[Month of Year].[Month of Year]", DateTimeGroupInterval.MonthYear);
            Card card = new Card();
            card.LayoutTemplate = new CardStretchedLayoutTemplate();
            card.ActualValue = new Measure("[Measures].[Internet Sales Amount]");
            card.TargetValue = new Measure("[Measures].[Sales Amount]");
            cardItem.Cards.Add(card);

            ChartDashboardItem chartItem = new ChartDashboardItem();
            chartItem.DataSource = olapDataSource;
            chartItem.Arguments.Add(new Dimension("[Sales Territory].[Sales Territory].[Country]"));
            chartItem.Panes.Add(new ChartPane());
            SimpleSeries salesAmountSeries = new SimpleSeries(SimpleSeriesType.Bar);
            salesAmountSeries.Value = new Measure("[Measures].[Sales Amount]");
            chartItem.Panes[0].Series.Add(salesAmountSeries);
            SimpleSeries salesInernetAmountSeries = new SimpleSeries(SimpleSeriesType.Bar);
            salesInernetAmountSeries.Value = new Measure("[Measures].[Internet Sales Amount]");
            chartItem.Panes[0].Series.Add(salesInernetAmountSeries);
            dBoard.Items.AddRange(cardItem, chartItem);

            DashboardLayoutItem cardLayoutItem = new DashboardLayoutItem(cardItem);
            DashboardLayoutItem chartLayoutItem = new DashboardLayoutItem(chartItem);
            DashboardLayoutGroup rootGroup = new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, 
                50D, cardLayoutItem, chartLayoutItem);
            dBoard.LayoutRoot = rootGroup;

            return dBoard;
        }
    }
}
