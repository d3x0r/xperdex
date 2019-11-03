using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace xperd3x.d3d.sprite_tester
{
	public class SpriteTest : PSI_DirectGrid, IReflectorPersistance
	{
		Sprite sprite;
		Texture texture = TextureLoader.FromFile(device, "image.bmp");

		Matrix m;
		
		void OnCreate( Device device )
		{
			sprite = new Sprite( device );
			m = new Matrix();
			//m.
			//sprite.Transform
		}

		void OnRender( )
		{
			sprite.Begin( SpriteFlags.AlphaBlend | SpriteFlags.Billboard );
			sprite.Draw( texture, Vector3.Empty, Vector3.Empty, 16777215 );
			sprite.Draw( texture, Vector3.Empty, Vector3.Empty, 16777215 );
			sprite.End();
			//sprite.Draw2D( 
		}


		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return false; 
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Properties()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
