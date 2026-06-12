using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Beanz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UISettingController : Controller
    {
        private readonly string _filePath;
        public UISettingController(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "Config", "ui-settings.json");
        }
        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<ActionResult<UISettingDTO>> GetUISetting()
        {
            if (!System.IO.File.Exists(_filePath))
            {
                var defaultData = GetDefault();
                await SaveToFile(defaultData);
                return Ok(defaultData);
            }

            var json = await System.IO.File.ReadAllTextAsync(_filePath);

            var data = JsonSerializer.Deserialize<UISettingDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (data == null)
                return BadRequest("Invalid UI setting JSON.");

            return Ok(data);
        }

        [HttpPost("set")]
        [Authorize]
        public async Task<ActionResult> SetUISetting([FromBody] UISettingDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data.");

            dto.UpdatedAt = DateTime.UtcNow;
            dto.UpdatedBy = User.Identity?.Name ?? "AuthorizedUser";

            await SaveToFile(dto);

            return Ok(new
            {
                message = "UI setting updated successfully."
            });
        }

        private async Task SaveToFile(UISettingDTO data)
        {
            var folder = Path.GetDirectoryName(_filePath);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder!);

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await System.IO.File.WriteAllTextAsync(_filePath, json);
        }

        private UISettingDTO GetDefault()
        {
            return new UISettingDTO
            {
                LoginUISettingId = 1,
                BrandName = "Beanz ERP",
                BrandSlogan = "Enterprise Solutions",
                brandNameColor = "",
                BrandSloganColor = "",
                BrandLogo = "logo.png",
                brandLogoColor = "",
                brandLogoSize = "",
                BrandNameSize = 0,
                BrandSloganSize = 0,
                brandLogoX = 0,
                brandLogoY = 0,
                BrandNameX = 0,
                BrandNameY = 0,
                HeroImageUrl = "hero.png",
                FooterText = "© 2026 Beanz ",
                TermsConditionText = "Terms & Conditions",
                WebSite = "www.BbeanzInnovations.com",
                PoweredBy = "Apcasoft Infosolutions Private Limited",
                PoweredLogoUrl = "PoweredLogo.png",
                ShowHeroPanel = true,
                ShowGoogleButton = true,
                ShowSignupLink = true,
                ShowFooter = true,
                ShowTermsConditionText = true,
                ShowWebSite = false,
                ShowPoweredBy = false,
                PrimaryColor = "217 91% 45%",
                GradientFrom = "217 91% 50%",
                GradientTo = "270 91% 65%",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System"
            };
        }

        public class UISettingDTO
        {
 
            public int LoginUISettingId { get; set; } = 1;

            public string BrandName { get; set; } = "Beanz ERP";
            public string BrandSlogan { get; set; } = "Enterprise Solutions";
            public string brandNameColor { get; set; } = "";
            public string BrandSloganColor { get; set; } = "";
            public string BrandLogo { get; set; } = "B";
            public string brandLogoColor { get; set; } = "";
            public string brandLogoSize { get; set; } = "";
            public int BrandNameSize { get; set; } = 12;
            public int BrandSloganSize { get; set; } = 10;

            public int brandLogoX { get; set; }
            public int brandLogoY { get; set; }
            public int BrandNameX { get; set; }
            public int BrandNameY { get; set; }
            public string HeroImageUrl { get; set; } = "";
            public string FooterText { get; set; } = "";
            public string TermsConditionText { get; set; } = "";
            public string WebSite { get; set; } = "";
            public string PoweredBy { get; set; } = "";
            public string PoweredLogoUrl { get; set; } = "";
            public bool ShowHeroPanel { get; set; } = true;
            public bool ShowGoogleButton { get; set; } = true;
            public bool ShowSignupLink { get; set; } = true;
            public bool ShowFooter { get; set; } = true;
            public bool ShowTermsConditionText { get; set; } = true;
            public bool ShowWebSite { get; set; } = false;
            public bool ShowPoweredBy { get; set; } = false;
            public string PrimaryColor { get; set; } = "217 91% 45%";
            public string GradientFrom { get; set; } = "217 91% 50%";
            public string GradientTo { get; set; } = "270 91% 65%";
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
            public string? UpdatedBy { get; set; }

        }
    }
}
