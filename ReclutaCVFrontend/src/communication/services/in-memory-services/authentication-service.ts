import { AuthenticationService } from "../authentication-service";

export const InMemoryAuthenticationService: AuthenticationService = {
    authenticateUsuario: (_: string, __: string) =>
        Promise.resolve(
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiU3VwZXJhZG1pbiIsIm5iZiI6MTU2MTY1OTYxMCwiZXhwIjoxNTYxNzQ2MDEwLCJpYXQiOjE1NjE2NTk2MTB9.pkVGsmm7SsiAV2qXq1EZlLolZRoStEQu9S7Kh6BtEGI"
        )
};
