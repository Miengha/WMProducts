import environment from 'environment';

export function AureliaApiConfig(config) {
  config.registerEndpoint('protected-api', environment.apiEndpoint);
  config.endpoints['protected-api'].client.configure(x => {
    x.withInterceptor({
      request(request) {
        return request;
      },

      requestError(error) {
        return error;
      },

      response(response) {
        // Status 403 may return an empty body and break response.json()
        if (response.status == 403) {
          return Error('Unauthorised User');
        }
        else if (!response.ok) {
          return response.json()
          .then(error => {
            return Error(error);
          });
        }

        return response;
      },

      responseError(error) {
        if (error.message && error.message == 'Failed to fetch')
          return Error('Unable to access the system at this time, please try again later.');

        return Error(error.message);
      }
    });
  });
}
