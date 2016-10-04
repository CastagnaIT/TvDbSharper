namespace TvDbSharper.RestClient
{
    using TvDbSharper.Authentication;
    using TvDbSharper.JsonClient;
    using TvDbSharper.Series;

    public class RestClient
    {
        public RestClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;

            this.Authentication = new AuthenticationClient(this.JsonClient);
            this.Series = new SeriesClient(this.JsonClient);
        }

        public IAuthenticationClient Authentication { get; }

        public ISeriesClient Series { get; }

        private IJsonClient JsonClient { get; }

        // public async Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken)
        // {
        // return await this.GetDataAsync<SearchResponse[]>($"/search/series?name={Uri.EscapeDataString(name)}", cancellationToken);

        // }
    }
}