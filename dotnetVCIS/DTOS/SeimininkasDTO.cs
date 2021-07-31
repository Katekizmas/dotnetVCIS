using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Dtos
{
    public record SeimininkasDTO
    {
            public Guid id_seimininkas { get; init; }
            public string vardas { get; init; }
            public string pavarde { get; init; }
            public string pastas { get; init; }
            public string telnr { get; init; }
            public string slaptazodis { get; init; }
    }
}
