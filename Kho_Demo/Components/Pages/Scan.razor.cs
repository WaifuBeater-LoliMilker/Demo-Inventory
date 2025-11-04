using Kho_Demo.Models;
using Kho_Demo.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
    public partial class Scan
    {
        [Inject] private NavigationManager Nav { get; set; } = default!;
        [Inject] private IJSRuntime JS { get; set; } = default!;
        [Inject] private IApiService apiService { get; set; } = default!;
        [Inject] private IAlertService alertService { get; set; } = default!;
        [Inject] private DataShareService dataShareService { get; set; } = default!;
        private string qrCode { get; set; } = "";
        private ElementReference qrInput;
        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            try
            {
                if (e.Code == "Enter" || e.Key == "Enter" || e.Code == "NumpadEnter")
                {
                    await JS.InvokeVoidAsync("toggleLoading", true);
                    var token = Preferences.Get("Token", "");
                    apiService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await apiService.Client.GetAsync($"api/api/ProductRTC/get-by-qrcode?qrCode={qrCode}");
                    var json = await response.Content.ReadAsStringAsync();
                    var qrInfoDTO = JsonConvert.DeserializeObject<QRInfoDTO>(json);
                    if (!String.IsNullOrEmpty(qrInfoDTO?.message)) throw new Exception(qrInfoDTO?.message);
                    await JS.InvokeVoidAsync("toggleLoading", false);
                    await JS.InvokeVoidAsync("selectAllText", qrInput);
                    if (!dataShareService.qrData.Any(d => qrInfoDTO!.data.Any(dn => d.ID == dn.ID)))
                    {
                        if(qrInfoDTO!.data.Count > 0)
                            dataShareService.qrData.Add(qrInfoDTO!.data[0]);
                        else
                            throw new Exception("This product is currently unavailable.");
                    }
                    else
                    {
                        var confirmDup = await alertService.ShowQuestionAsync("Notice",
                            "This code has already been added, do you want to add again?", "OK", "Cancel");
                        if (confirmDup) dataShareService.qrData.Add(qrInfoDTO!.data[0]);
                    };
                }
            }
            catch (Exception ex)
            {
                await JS.InvokeVoidAsync("toggleLoading", false);
                await alertService.ShowAsync("Notice", ex.Message, "OK");
            }
        }
        public void OnConfirm()
        {
            Nav.NavigateTo($"/confirm");
        }
    }
}
