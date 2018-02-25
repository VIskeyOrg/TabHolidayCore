using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models
{
    public  class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // For sample purposes we are seeding 2 users both with the same password.
                // The password is set with the following command:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@tabholiday.com", "Admin");
                await EnsureRole(serviceProvider, adminID, "IT Admin");

                await CreateRoles(serviceProvider,  "Travel Agent");
                await CreateRoles(serviceProvider, "DMC");
                await CreateRoles(serviceProvider, "B2B");


                SeedTierLevel(context);
                SeedCountries(context);
                SeedDMCOfficialTypes(context);
                SeedBankAccountTypes(context);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName,string ActualName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);

            
            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName,ActualName = ActualName };
                await userManager.CreateAsync(user, testUserPw);                
            }

            return user.UserName;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
           
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);


            return IR;
        }

        private static async Task<IdentityResult> CreateRoles(IServiceProvider serviceProvider,
                                                                      string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new ApplicationRole(role));
            }

            return IR;

        }

        private static void SeedTierLevel(AppDbContext context)
        {
            if(context.AgencyTierLevels.Any())
            {
                return;
            }

            context.AgencyTierLevels.AddRange(
                new AgencyTierLevel { Name="Tier 1" },
                new AgencyTierLevel { Name = "Tier 2" },
                new AgencyTierLevel { Name = "Tier 3" },
                new AgencyTierLevel { Name = "Tier 4" },
                new AgencyTierLevel { Name = "Tier 5" }
                );

            context.SaveChanges();
        }

        private static void SeedBankAccountTypes(AppDbContext context)
        {
            if (context.BankAccountTypes.Any())
            {
                return;
            }

            context.BankAccountTypes.AddRange(
                new BankAccountType { Name = "Savings" },
                new BankAccountType { Name = "Current" }
                );

            context.SaveChanges();
        }

        private static void SeedDMCOfficialTypes(AppDbContext context)
        {
            if (context.DMCOfficialTypes.Any())
            {
                return;
            }

            context.DMCOfficialTypes.AddRange(
                new DMCOfficialType { Name = "Ops" },
                new DMCOfficialType { Name = "Sales" },
                new DMCOfficialType { Name = "Account" },
                new DMCOfficialType { Name = "Management" }
                );

            context.SaveChanges();
        }

        private static void SeedCountries(AppDbContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.AddRange(                
                new Country { Name = "Afghanistan", Extention = "AF" },
                new Country { Name = "Albania", Extention = "AL" },
                new Country { Name = "Algeria", Extention = "DZ" },
                new Country { Name = "Aland Islands", Extention = "AX" },
                new Country { Name = "American Samoa", Extention = "AS" },
                new Country { Name = "Anguilla", Extention = "AI" },
                new Country { Name = "Andorra", Extention = "AD" },
                new Country { Name = "Angola", Extention = "AO" },
                new Country { Name = "Antilles - Netherlands", Extention = "AN" },
                new Country { Name = "Antigua and Barbuda", Extention = "AG" },
                new Country { Name = "Antarctica", Extention = "AQ" },
                new Country { Name = "Argentina", Extention = "AR" },
                new Country { Name = "Armenia", Extention = "AM" },
                new Country { Name = "Australia", Extention = "AU" },
                new Country { Name = "Austria", Extention = "AT" },
                new Country { Name = "Aruba", Extention = "AW" },
                new Country { Name = "Azerbaijan", Extention = "AZ" },
                new Country { Name = "Bosnia and Herzegovina", Extention = "BA" },
                new Country { Name = "Barbados", Extention = "BB" },
                new Country { Name = "Bangladesh", Extention = "BD" },
                new Country { Name = "Belgium", Extention = "BE" },
                new Country { Name = "Burkina Faso", Extention = "BF" },
                new Country { Name = "Bulgaria", Extention = "BG" },
                new Country { Name = "Bahrain", Extention = "BH" },
                new Country { Name = "Burundi", Extention = "BI" },
                new Country { Name = "Benin", Extention = "BJ" },
                new Country { Name = "Bermuda", Extention = "BM" },
                new Country { Name = "Brunei Darussalam", Extention = "BN" },
                new Country { Name = "Bolivia", Extention = "BO" },
                new Country { Name = "Brazil", Extention = "BR" },
                new Country { Name = "Bahamas", Extention = "BS" },
                new Country { Name = "Bhutan", Extention = "BT" },
                new Country { Name = "Bouvet Island", Extention = "BV" },
                new Country { Name = "Botswana", Extention = "BW" },
                new Country { Name = "Belarus", Extention = "BV" },
                new Country { Name = "Belize", Extention = "BZ" },
                new Country { Name = "Cambodia", Extention = "KH" },
                new Country { Name = "Cameroon", Extention = "CM" },
                new Country { Name = "Canada", Extention = "CA" },
                new Country { Name = "Cape Verde", Extention = "CV" },
                new Country { Name = "Central African Republic", Extention = "CF" },
                new Country { Name = "Chad", Extention = "TD" },
                new Country { Name = "Chile", Extention = "CL" },
                new Country { Name = "China", Extention = "CN" },
                new Country { Name = "Christmas Island", Extention = "CX" },
                new Country { Name = "Cocos (Keeling) Islands", Extention = "CC" },
                new Country { Name = "Colombia", Extention = "CO" },
                new Country { Name = "Congo", Extention = "CG" },
                new Country { Name = "Cote D'Ivoire (Ivory Coast)", Extention = "CI" },
                new Country { Name = "Cook Islands", Extention = "CK" },
                new Country { Name = "Costa Rica", Extention = "CR" },
                new Country { Name = "Croatia (Hrvatska)", Extention = "HR" },
                new Country { Name = "Cuba", Extention = "CU" },
                new Country { Name = "Cyprus", Extention = "CY" },
                new Country { Name = "Czech Republic", Extention = "CZ" },
                new Country { Name = "Democratic Republic of the Congo", Extention = "CD" },
                new Country { Name = "Djibouti", Extention = "DJ" },
                new Country { Name = "Denmark", Extention = "DK" },
                new Country { Name = "Dominica", Extention = "DM" },
                new Country { Name = "Dominican Republic", Extention = "DO" },
                new Country { Name = "Ecuador", Extention = "EC" },
                new Country { Name = "Egypt", Extention = "EG" },
                new Country { Name = "El Salvador", Extention = "SV" },
                new Country { Name = "East Timor", Extention = "TP" },
                new Country { Name = "Estonia", Extention = "EE" },
                new Country { Name = "Equatorial Guinea", Extention = "GQ" },
                new Country { Name = "Eritrea", Extention = "ER" },
                new Country { Name = "Ethiopia", Extention = "ET" },
                new Country { Name = "Finland", Extention = "FI" },
                new Country { Name = "Fiji", Extention = "FJ" },
                new Country { Name = "Falkland Islands (Malvinas)", Extention = "FK" },
                new Country { Name = "Federated States of Micronesia", Extention = "FM" },
                new Country { Name = "Faroe Islands", Extention = "FO" },
                new Country { Name = "France", Extention = "FR" },
                new Country { Name = "France, Metropolitan", Extention = "FX" },
                new Country { Name = "French Guiana", Extention = "GF" },
                new Country { Name = "French Polynesia", Extention = "PF" },
                new Country { Name = "Gabon", Extention = "GA" },
                new Country { Name = "Gambia", Extention = "GM" },
                new Country { Name = "Germany", Extention = "DE" },
                new Country { Name = "Ghana", Extention = "GH" },
                new Country { Name = "Gibraltar", Extention = "GI" },
                new Country { Name = "Great Britain (UK)", Extention = "GB" },
                new Country { Name = "Grenada", Extention = "GD" },
                new Country { Name = "Georgia", Extention = "GE" },
                new Country { Name = "Greece", Extention = "GR" },
                new Country { Name = "Greenland", Extention = "GL" },
                new Country { Name = "Guinea", Extention = "GN" },
                new Country { Name = "Guadeloupe", Extention = "GP" },
                new Country { Name = "S. Georgia and S. Sandwich Islands", Extention = "GS" },
                new Country { Name = "Guatemala", Extention = "GT" },
                new Country { Name = "Guam", Extention = "GU" },
                new Country { Name = "Guinea-Bissau", Extention = "GW" },
                new Country { Name = "Guyana", Extention = "GY" },
                new Country { Name = "Hong Kong", Extention = "HK" },
                new Country { Name = "Heard Island and McDonald Islands", Extention = "HM" },
                new Country { Name = "Honduras", Extention = "HN" },
                new Country { Name = "Haiti", Extention = "HT" },
                new Country { Name = "Hungary", Extention = "HU" },
                new Country { Name = "Indonesia", Extention = "ID" },
                new Country { Name = "Ireland", Extention = "IE" },
                new Country { Name = "Israel", Extention = "IL" },
                new Country { Name = "India", Extention = "IN" },
                new Country { Name = "British Indian Ocean Territory", Extention = "IO" },
                new Country { Name = "Iraq", Extention = "IQ" },
                new Country { Name = "Iran", Extention = "IR" },
                new Country { Name = "Italy", Extention = "IT" },
                new Country { Name = "Jamaica", Extention = "JM" },
                new Country { Name = "Jordan", Extention = "JO" },
                new Country { Name = "Japan", Extention = "JP" },
                new Country { Name = "Kenya", Extention = "KE" },
                new Country { Name = "Kyrgyzstan", Extention = "KG" },
                new Country { Name = "Kiribati", Extention = "KI" },
                new Country { Name = "Comoros", Extention = "KM" },
                new Country { Name = "Saint Kitts and Nevis", Extention = "KN" },
                new Country { Name = "Korea (North)", Extention = "KP" },
                new Country { Name = "Korea (South)", Extention = "KR" },
                new Country { Name = "Kuwait", Extention = "KW" },
                new Country { Name = "Cayman Islands", Extention = "KY" },
                new Country { Name = "Kazakhstan", Extention = "KZ" },
                new Country { Name = "Laos", Extention = "LA" },
                new Country { Name = "Lebanon", Extention = "LB" },
                new Country { Name = "Saint Lucia", Extention = "LC" },
                new Country { Name = "Liechtenstein", Extention = "LI" },
                new Country { Name = "Sri Lanka", Extention = "LK" },
                new Country { Name = "Liberia", Extention = "LR" },
                new Country { Name = "Lesotho", Extention = "LS" },
                new Country { Name = "Lithuania", Extention = "LT" },
                new Country { Name = "Luxembourg", Extention = "LU" },
                new Country { Name = "Latvia", Extention = "LV" },
                new Country { Name = "Libya", Extention = "LY" },
                new Country { Name = "Macedonia", Extention = "MK" },
                new Country { Name = "Macao", Extention = "MO" },
                new Country { Name = "Madagascar", Extention = "MG" },
                new Country { Name = "Malaysia", Extention = "MY" },
                new Country { Name = "Mali", Extention = "ML" },
                new Country { Name = "Malawi", Extention = "MW" },
                new Country { Name = "Mauritania", Extention = "MR" },
                new Country { Name = "Marshall Islands", Extention = "MH" },
                new Country { Name = "Martinique", Extention = "MQ" },
                new Country { Name = "Mauritius", Extention = "MU" },
                new Country { Name = "Mayotte", Extention = "YT" },
                new Country { Name = "Malta", Extention = "MT" },
                new Country { Name = "Mexico", Extention = "MX" },
                new Country { Name = "Morocco", Extention = "MA" },
                new Country { Name = "Monaco", Extention = "MC" },
                new Country { Name = "Moldova", Extention = "MD" },
                new Country { Name = "Mongolia", Extention = "MN" },
                new Country { Name = "Myanmar", Extention = "MM" },
                new Country { Name = "Northern Mariana Islands", Extention = "MP" },
                new Country { Name = "Montserrat", Extention = "MS" },
                new Country { Name = "Maldives", Extention = "MV" },
                new Country { Name = "Mozambique", Extention = "MZ" },
                new Country { Name = "Namibia", Extention = "NA" },
                new Country { Name = "New Caledonia", Extention = "NC" },
                new Country { Name = "Niger", Extention = "NE" },
                new Country { Name = "Norfolk Island", Extention = "NF" },
                new Country { Name = "Nigeria", Extention = "NG" },
                new Country { Name = "Nicaragua", Extention = "NI" },
                new Country { Name = "Netherlands", Extention = "NL" },
                new Country { Name = "Norway", Extention = "NO" },
                new Country { Name = "Nepal", Extention = "NP" },
                new Country { Name = "Nauru", Extention = "NR" },
                new Country { Name = "Niue", Extention = "NU" },
                new Country { Name = "New Zealand (Aotearoa)", Extention = "NZ" },
                new Country { Name = "Oman", Extention = "OM" },
                new Country { Name = "Panama", Extention = "PA" },
                new Country { Name = "Peru", Extention = "PE" },
                new Country { Name = "Papua New Guinea", Extention = "PG" },
                new Country { Name = "Philippines", Extention = "PH" },
                new Country { Name = "Pakistan", Extention = "PK" },
                new Country { Name = "Poland", Extention = "PL" },
                new Country { Name = "Saint Pierre and Miquelon", Extention = "PM" },
                new Country { Name = "Serbia and Montenegro", Extention = "CS" },
                new Country { Name = "Pitcairn", Extention = "PN" },
                new Country { Name = "Puerto Rico", Extention = "PR" },
                new Country { Name = "Palestinian Territory", Extention = "PS" },
                new Country { Name = "Portugal", Extention = "PT" },
                new Country { Name = "Palau", Extention = "PW" },
                new Country { Name = "Paraguay", Extention = "PY" },
                new Country { Name = "Qatar", Extention = "QA" },
                new Country { Name = "Reunion", Extention = "RE" },
                new Country { Name = "Romania", Extention = "RO" },
                new Country { Name = "Russian Federation", Extention = "RU" },
                new Country { Name = "Rwanda", Extention = "RW" },
                new Country { Name = "Saudi Arabia", Extention = "SA" },
                new Country { Name = "Samoa", Extention = "WS" },
                new Country { Name = "Saint Helena", Extention = "SH" },
                new Country { Name = "Saint Vincent and the Grenadines", Extention = "VC" },
                new Country { Name = "San Marino", Extention = "SM" },
                new Country { Name = "Sao Tome and Principe", Extention = "ST" },
                new Country { Name = "Senegal", Extention = "SN" },
                new Country { Name = "Seychelles", Extention = "SC" },
                new Country { Name = "Sierra Leone", Extention = "SL" },
                new Country { Name = "Singapore", Extention = "SG" },
                new Country { Name = "Slovakia", Extention = "SK" },
                new Country { Name = "Slovenia", Extention = "SI" },
                new Country { Name = "Solomon Islands", Extention = "SB" },
                new Country { Name = "Somalia", Extention = "SO" },
                new Country { Name = "South Africa", Extention = "ZA" },
                new Country { Name = "Spain", Extention = "ES" },
                new Country { Name = "Sudan", Extention = "SD" },
                new Country { Name = "Suriname", Extention = "SR" },
                new Country { Name = "Svalbard and Jan Mayen", Extention = "SJ" },
                new Country { Name = "Sweden", Extention = "SE" },
                new Country { Name = "Switzerland", Extention = "CH" },
                new Country { Name = "Syria", Extention = "SY" },
                new Country { Name = "USSR (former)", Extention = "SU" },
                new Country { Name = "Swaziland", Extention = "SZ" },
                new Country { Name = "Taiwan", Extention = "TW" },
                new Country { Name = "Tanzania", Extention = "TZ" },
                new Country { Name = "Tajikistan", Extention = "TJ" },
                new Country { Name = "Thailand", Extention = "TH" },
                new Country { Name = "Timor-Leste", Extention = "TL" },
                new Country { Name = "Togo", Extention = "TG" },
                new Country { Name = "Tokelau", Extention = "TK" },
                new Country { Name = "Tonga", Extention = "TO" },
                new Country { Name = "Trinidad and Tobago", Extention = "TT" },
                new Country { Name = "Tunisia", Extention = "TN" },
                new Country { Name = "Turkey", Extention = "TR" },
                new Country { Name = "Turkmenistan", Extention = "TM" },
                new Country { Name = "Turks and Caicos Islands", Extention = "TC" },
                new Country { Name = "Tuvalu", Extention = "TV" },
                new Country { Name = "Ukraine", Extention = "UA" },
                new Country { Name = "Uganda", Extention = "UG" },
                new Country { Name = "United Arab Emirates", Extention = "AE" },
                new Country { Name = "United Kingdom", Extention = "UK" },
                new Country { Name = "United States", Extention = "US" },
                new Country { Name = "United States Minor Outlying Islands", Extention = "UM" },
                new Country { Name = "Uruguay", Extention = "UY" },
                new Country { Name = "Uzbekistan", Extention = "UZ" },
                new Country { Name = "Vanuatu", Extention = "VU" },
                new Country { Name = "Vatican City State", Extention = "VA" },
                new Country { Name = "Venezuela", Extention = "VE" },
                new Country { Name = "Virgin Islands (British)", Extention = "VG" },
                new Country { Name = "Virgin Islands (U.S.)", Extention = "VI" },
                new Country { Name = "Viet Nam", Extention = "VN" },
                new Country { Name = "Wallis and Futuna", Extention = "WF" },
                new Country { Name = "Western Sahara", Extention = "EH" },
                new Country { Name = "Yemen", Extention = "YE" },
                new Country { Name = "Yugoslavia (former)", Extention = "YU" },
                new Country { Name = "Zambia", Extention = "ZM" },
                new Country { Name = "Zaire (former)", Extention = "ZR" },
                new Country { Name = "Zimbabwe", Extention = "ZW" }

                );

            context.SaveChanges();
        }



    }

}
