import { ErrorHandler } from "@angular/core";

export class MyErrorHandler implements ErrorHandler {

    handleError(error: any) {
      alert("Something went wrong! Error message: " + error);
    }
  }