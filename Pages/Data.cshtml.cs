using ChartExample.ChartModels.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace NewEasyPeasy.Pages
{
	public class DataModel : PageModel
	{
		public ChartJs Chart { get; set; }
		public string ChartJson { get; set; }
		public void OnGet()
		{
			//Ref: https://www.chartjs.org/docs/latest/

			var chartData = @"
{
type: 'bar',
responsive: true,
data:
{
labels: ['Math', 'English', 'Shapes and colors', 'Break'],
 

    datasets: [{

data: [12, 19, 3, 53],
backgroundColor: [
'rgba(255, 99, 132, 0.2)',
'rgba(54, 162, 235, 0.2)',
'rgba(255, 206, 86, 0.2)',
'rgba(75, 192, 192, 0.2)'

],
borderColor: [
'rgba(255, 99, 132, 1)',
'rgba(54, 162, 235, 1)',
'rgba(255, 206, 86, 1)',
'rgba(75, 192, 192, 1)'

],
borderWidth: 1
}]
},
options:
{
scales:
{
        y: [{
ticks:
{
beginAtZero: true
}
}]
}
}
}";
			//end of chartdata
			Chart = JsonConvert.DeserializeObject<ChartJs>(chartData);
			ChartJson = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
			});
		} //end of OnGet()
	}
}
