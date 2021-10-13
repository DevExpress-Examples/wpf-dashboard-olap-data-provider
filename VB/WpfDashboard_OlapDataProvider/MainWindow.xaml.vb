Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports System.Windows

Namespace WpfDashboard_OlapDataProvider

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            dashboardControl1.Dashboard = CreateDashboard()
        End Sub

        Private Function CreateDashboard() As Dashboard
            Dim dBoard As Dashboard = New Dashboard()
            Dim olapParams As OlapConnectionParameters = New OlapConnectionParameters()
            olapParams.ConnectionString = "provider=MSOLAP;
                                  data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;
                                  initial catalog=Adventure Works DW Standard Edition;
                                  cube name=Adventure Works;"
            Dim olapDataSource As DashboardOlapDataSource = New DashboardOlapDataSource(olapParams)
            dBoard.DataSources.Add(olapDataSource)
            Dim cardItem As CardDashboardItem = New CardDashboardItem()
            cardItem.DataSource = olapDataSource
            cardItem.SeriesDimensions.Add(New Dimension("[Sales Territory].[Sales Territory Country].[Sales Territory Country]"))
            cardItem.SparklineArgument = New Dimension("[Date].[Month of Year].[Month of Year]", DateTimeGroupInterval.MonthYear)
            Dim card As Card = New Card()
            card.LayoutTemplate = New CardStretchedLayoutTemplate()
             ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             card.ActualValue = new Measure("[Measures].[Internet Sales Amount]")
'''   ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             card.TargetValue = new Measure("[Measures].[Sales Amount]")
'''  cardItem.Cards.Add(card)
            Dim chartItem As ChartDashboardItem = New ChartDashboardItem()
            chartItem.DataSource = olapDataSource
            chartItem.Arguments.Add(New Dimension("[Sales Territory].[Sales Territory].[Country]"))
            chartItem.Panes.Add(New ChartPane())
            Dim salesAmountSeries As SimpleSeries = New SimpleSeries(SimpleSeriesType.Bar)
             ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             salesAmountSeries.Value = new Measure("[Measures].[Sales Amount]")
'''  chartItem.Panes(0).Series.Add(salesAmountSeries)
            Dim salesInernetAmountSeries As SimpleSeries = New SimpleSeries(SimpleSeriesType.Bar)
             ''' Cannot convert AssignmentExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             salesInernetAmountSeries.Value = new Measure("[Measures].[Internet Sales Amount]")
'''  chartItem.Panes(0).Series.Add(salesInernetAmountSeries)
            dBoard.Items.AddRange(cardItem, chartItem)
            Dim cardLayoutItem As DashboardLayoutItem = New DashboardLayoutItem(cardItem)
            Dim chartLayoutItem As DashboardLayoutItem = New DashboardLayoutItem(chartItem)
            Dim rootGroup As DashboardLayoutGroup = New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, 50R, cardLayoutItem, chartLayoutItem)
            dBoard.LayoutRoot = rootGroup
            Return dBoard
        End Function
    End Class
End Namespace
