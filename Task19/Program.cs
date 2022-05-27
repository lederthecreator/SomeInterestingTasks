using System.Security.Cryptography;
using Task19.Domain;
using Task19.Repositories;

using var session = NHibernateHelper.OpenSession();
using var tx = session.BeginTransaction();

var worker = session.Get<Worker>((Int64)20);
Console.WriteLine(worker.Name);
worker.Name = "OtherName";
worker.Login = "OtherLogin";
session.Update(worker);
tx.Commit();