import * as APIService from "../utils/apiRequestUtils";

export const getUserEmploymentsInfo = (orcid) => {
  return APIService.getRequest(orcid + "/employments", {
    Authorization: "bearer " + "f1c0d2ec-6693-4739-bc10-ce02fb784884",
    "Access-Control-Allow-Origin": "*",
    crossDomain: true,
    // "Content-Type": "application/x-www-form-urlencoded",
    // "Accept-Encoding": "gzip, deflate, br",
    // Accept: "application/vnd.orcid+xml",
    // "User-Agent": "PostmanRuntime/7.26.8",
    // Host: "api.sandbox.orcid.org",
  });
};
