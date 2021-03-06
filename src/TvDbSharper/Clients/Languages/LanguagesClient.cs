﻿namespace TvDbSharper.Clients.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Languages.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class LanguagesClient : BaseClient, ILanguagesClient
    {
        internal LanguagesClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/languages";

                return this.GetAsync<Language[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Languages.GetAllAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<Language[]>> GetAllAsync()
        {
            return this.GetAllAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/languages/{languageId}";

                return this.GetAsync<Language>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Languages.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<Language>> GetAsync(int languageId)
        {
            return this.GetAsync(languageId, CancellationToken.None);
        }
    }
}