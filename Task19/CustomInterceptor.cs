using System.Diagnostics;
using System.Text;
using NHibernate.SqlCommand;
using NHibernate;

namespace Task19;

public class CustomInterceptor : EmptyInterceptor
{
    //sqlstring посмотреть 
    public override SqlString OnPrepareStatement(SqlString sql)
    {
        Debug.Write("NHibernate: ");
        Debug.WriteLine(sql);
        using var sw = new StreamWriter(@$"{DateTime.Now:dd-MMM-yyyy}log.sql", true, Encoding.Default);
        sw.Write(sql);
        sw.Close();
        return base.OnPrepareStatement(sql);
    }
}