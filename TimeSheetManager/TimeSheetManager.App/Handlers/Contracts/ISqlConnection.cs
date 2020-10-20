using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TimeSheetManager.App.Handlers.Contracts {
    public interface ISqlConnection {
        IDbConnection GetOpenConnection();
    }
}
