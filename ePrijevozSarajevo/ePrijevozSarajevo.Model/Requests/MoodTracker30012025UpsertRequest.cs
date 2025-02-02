using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrijevozSarajevo.Model.Requests
{
    public class MoodTracker30012025UpsertRequest
    {
        public int? UserId { get; set; }
        public int? VrijednostRaspolozenjaId { get; set; }
        public string? Opis { get; set; }
        public DateTime DatumEvidencije { get; set; }
    }
}
