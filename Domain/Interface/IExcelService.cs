using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IExcelService
    {
        Task<bool> ProcessExcelFileAsync(Stream excelStream);
    }
}
