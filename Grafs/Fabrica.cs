using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Grafs
{
    public class Fabrica: MyStorage
    {
		public override Shape createShape(string code)
		{
			switch (code)
			{

				case "S":
					return new Square();
				case "C":
					return new CCircle();
				case "T":
					return new Triangle();
				case "G":
					return new CGroup(15, new RectangleF());
				default:
					return null;

			}
		}
	}
}
