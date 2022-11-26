This application is a short demostration of a .NET Web API returning lists of prime numbers between 1 and 100, consumed by an Angular client. Therefore, it is far from perfect, and is not production-ready. 

Below is a number of potential changes that - given enough time - could be done to the project to improve on the situation.

# Backend

## Code
- Use global exception handling.
- Make the upper limit of primes list API configurable: for example, move it to the appsettings, and maybe inject an options class into the primes manager. 
- Introduce logging.
- Add production configuration.

## Security
Other than using HTTPS, the API is currently everything but secure. Theoretically, the following improvements could be carried out (and even more not listed here).

- Properly configuring the use of CORS - currently every origin is allowed.
- Adding API rate-limiting middleware.
- Introducing authentication.
- Adding an ingress layer.

# Angular Client
## UI
- Potential UI improvements 
    - Making it mobile-friendly (e.g. with Bootstrap and/or with Angular Material).
    - Displayig proper error messages.
    - Remindig users that 1 is not a prime number (currently an empty list comes back).
    - Making the UI look better in general.

## Code
- More separation of concerns, e.g. creating environment variables for API urls, etc.
- Proper error handling for the API. Currently, everything is dumped into an error message field.
- Better unit test coverage: shallow integration tests involving the UI, and proper testing of error scenarios.
- Proper CSS structuring - the current implementation is ad-hoc for fast results.
- Introduce logging.

# Containers

- Create Docker container images for both back-end and client.
- Use container orchestration (e.g. K8) to manage said containers and scale if needed.