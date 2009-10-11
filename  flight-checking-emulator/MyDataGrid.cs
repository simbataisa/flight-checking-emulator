
using System;
using System.Windows.Forms;

namespace FlightCheckingEmulator
{
	/// <summary>
	/// Description of MyDataGrid.
	/// </summary>
	public class MyDataGrid : DataGrid
	{
		protected override void OnMouseDown(MouseEventArgs e)
		{
			System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);
			DataGrid.HitTestInfo hti = this.HitTest(pt);
			if( hti.Type == HitTestType.ColumnHeader 
			   || hti.Type == HitTestType.Cell)
				return;
			
			base.OnMouseDown(e);
		}
	}
}
