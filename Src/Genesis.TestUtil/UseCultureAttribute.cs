namespace Genesis.TestUtil
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using Xunit.Sdk;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UseCultureAttribute : BeforeAfterTestAttribute
    {
        private readonly Lazy<CultureInfo> culture;
        private readonly Lazy<CultureInfo> uiCulture;
        private CultureInfo originalCulture;
        private CultureInfo originalUICulture;

        public UseCultureAttribute(string culture)
            : this(culture, culture)
        {
        }

        public UseCultureAttribute(string culture, string uiCulture)
        {
            this.culture = new Lazy<CultureInfo>(() => new CultureInfo(culture));
            this.uiCulture = new Lazy<CultureInfo>(() => new CultureInfo(uiCulture));
        }

        public CultureInfo Culture => culture.Value;

        public CultureInfo UICulture => uiCulture.Value;

        public override void Before(MethodInfo methodUnderTest)
        {
            this.originalCulture = CultureInfo.DefaultThreadCurrentCulture;
            this.originalUICulture = CultureInfo.DefaultThreadCurrentUICulture;

            CultureInfo.DefaultThreadCurrentCulture = this.Culture;
            CultureInfo.DefaultThreadCurrentUICulture = this.UICulture;
        }

        public override void After(MethodInfo methodUnderTest)
        {
            CultureInfo.DefaultThreadCurrentCulture = this.originalCulture;
            CultureInfo.DefaultThreadCurrentUICulture = this.originalUICulture;
        }
    }
}