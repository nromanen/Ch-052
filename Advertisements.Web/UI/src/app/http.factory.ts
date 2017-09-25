import { XHRBackend, Http, RequestOptions } from "@angular/http";
import { InterceptedHttp } from "./http.interceptor";
import { ComcomService } from './services/comcom.service'



export function httpFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions, comcomService: ComcomService): Http {
    return new InterceptedHttp(xhrBackend, requestOptions, comcomService);
}