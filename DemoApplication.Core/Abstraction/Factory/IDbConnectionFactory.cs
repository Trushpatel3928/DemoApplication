using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DemoApplication.Core.Abstraction.Factory
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
