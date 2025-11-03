using Kho_Demo.Models;
using Kho_Demo.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Components.Pages
{
    public partial class Confirm
    {
        [Inject] private NavigationManager Nav { get; set; } = default!;
        [Inject] private IJSRuntime JS { get; set; } = default!;
        [Inject] private IApiService apiService { get; set; } = default!;
        [Inject] private IAlertService alertService { get; set; } = default!;
        [Inject] private DataShareService dataShareService { get; set; } = default!;
        private DateTime borrowDate { get; set; } = DateTime.Now;
        private DateTime returnDate { get; set; } = DateTime.Now;
        private string projectCode { get; set; } = "";
        private string note { get; set; } = "";
        public async Task OnConfirm()
        {
            try
            {
                await JS.InvokeVoidAsync("toggleLoading", true);
                var saveData = new List<BorrowRecord>();
                foreach(var item in dataShareService.qrData)
                {
                    saveData.Add(new BorrowRecord
                    {
                        DateBorrow = borrowDate,
                        DateReturnExpected = returnDate,
                        Project = projectCode,
                        Note = note
                    });
                }
                if(saveData.Count > 0)
                {
                    var serialized = JsonConvert.SerializeObject(saveData);
                    var jsonContent = new StringContent(serialized,
                        Encoding.UTF8,
                        "application/json");
                    var token = Preferences.Get("Token", "");
                    apiService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await apiService.Client.PostAsync($"rerpapi/api/historyproductrtc/save-data", jsonContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Something wrong happened, please try again.");
                    }

                    var json = await response.Content.ReadAsStringAsync();
                }
                await JS.InvokeVoidAsync("toggleLoading", false);
                Nav.NavigateTo($"/");
            }
            catch (Exception ex)
            {
                await JS.InvokeVoidAsync("toggleLoading", false);
                await alertService.ShowAsync("Notice", ex.Message, "OK");
            }
        }
    }
}
