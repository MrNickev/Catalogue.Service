using System.Collections.Generic;

namespace Application.Avtomoe.Models;

public class AvtomoeResponseData
{
    /// <summary>
    /// Предложения по запрошенному артикулу
    /// </summary>
    public List<AvtomoePartInfo> RequestedOffers { get; set; }
    
    /// <summary>
    /// Предложения по аналогам запрошенного артикула
    /// </summary>
    public List<AvtomoePartInfo> AnalogOffers { get; set; }
}