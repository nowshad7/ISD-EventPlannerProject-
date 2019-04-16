using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemEvent.Models;

namespace GemDB.DBFunctions
{
	public class Client
	{
		public int Register(ClientModel model)
		{
			using (var context = new GemDBEntities())
			{
				Clients c = new Clients()
				{
					Name = model.Name,
					Email = model.Email,
					Phone =model.Phone,
					Address= model.Address,
					Password=model.Password
				};
				context.Clients.Add(c);
				context.SaveChanges();
				return c.ClientID;


			}
		}

	}
}
