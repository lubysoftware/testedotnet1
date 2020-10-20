using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.Contracts;
using TimeSheetManager.App.Handlers.Contracts;
using TimeSheetManager.Domain;
using TimeSheetManager.Domain.Extensions;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Domain.TimeSheetNS;

namespace TimeSheetManager.App.Handlers.TimeSheetNS
{
    public class GetWeekRankingHandler
    {
        private readonly ISqlConnection sqlConnection;

        public GetWeekRankingHandler(ISqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public async Task<ICommandResult> Handle()
        {
            var connection = sqlConnection.GetOpenConnection();
            var week = DateTime.Now.WeekNumberOfTheYear();

            var data = await connection.QueryAsync<Ranking>("SELECT TOP (5) DevID, Name,  SUM(TotalHours) as WorkedTime FROM TimeSheet" +
                $" ts INNER JOIN Developers dv ON dv.Id = ts.DevId WHERE WeekId = {week} GROUP BY DevId, Name ORDER BY WorkedTime DESC");

            return new GenericCommandResult(true, "Sucess", data);
        }
    }
}

