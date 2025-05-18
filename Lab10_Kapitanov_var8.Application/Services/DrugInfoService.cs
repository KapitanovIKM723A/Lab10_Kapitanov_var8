using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Infrastructure.ExternalApis;

namespace Lab10_Kapitanov_var8.Application.Services
{
    public class DrugInfoService
    {
        private readonly DrugInfoRepository _repo;
        public DrugInfoService(DrugInfoRepository repo) => _repo = repo;

        public async Task<string?> GetUsageAsync(string drugName)
        {
            var resp = await _repo.GetLabelByNameAsync(drugName);
            var first = resp?.Results?.FirstOrDefault();
            if (first == null) return null;

            var sb = new StringBuilder();

            if (first.Purpose?.Any() == true)
                sb.AppendLine($"Призначення: {first.Purpose.First()}");

            if (first.Indications_and_Usage?.Any() == true)
            {
                sb.AppendLine("Показання:");
                foreach (var line in first.Indications_and_Usage)
                    sb.AppendLine($"  – {line}");
            }

            return sb.ToString();
        }
    }
}
