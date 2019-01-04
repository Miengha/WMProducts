export default {
  endpoint: 'protected-api',             // use 'auth' endpoint for the auth server
  configureEndpoints: ['protected-api'], // add Authorization header to 'auth' endpoint
  loginUrl: 'api/v2/login',
  storageChangedReload: true,    // ensure secondary tab reloading after auth status changes
  expiredRedirect: '/',          // redirect to logoutRedirect after token expiration
  logoutRedirect: '#/'
}
