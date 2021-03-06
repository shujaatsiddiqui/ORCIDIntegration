import * as APIService from "../utils/apiRequestUtils";

export const getUserDetails = (orcid) => {
  //debugger;
  return APIService.getRequest("OrcidIntegration/" + orcid, {
    //Authorization: "bearer " + "f1c0d2ec-6693-4739-bc10-ce02fb784884",
    "Access-Control-Allow-Origin": "*",
    crossDomain: true,
    // "Content-Type": "application/x-www-form-urlencoded",
    // "Accept-Encoding": "gzip, deflate, br",
    // Accept: "application/vnd.orcid+xml",
    // "User-Agent": "PostmanRuntime/7.26.8",
    // Host: "api.sandbox.orcid.org",
  });
};

export const fetchUserDetails = (orcid) => {
  return APIService.getRequest("OrcidIntegration/FetchDetail/" + orcid, {
    "Access-Control-Allow-Origin": "*",
    crossDomain: true,
  });
};

export const GetAccessTokenFromCode = (code) => {
  //debugger;
  return APIService.postRequest(
    "OrcidIntegration/accesstoken/",
    JSON.stringify({ code: code }),
    {
      "Access-Control-Allow-Origin": "*",
      crossDomain: true,
      "Content-Type": "application/json",
    }
  );
};
