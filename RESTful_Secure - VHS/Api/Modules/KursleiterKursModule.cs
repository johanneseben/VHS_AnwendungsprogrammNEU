﻿using Common.Services;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Common.Models;
using Nancy.Serialization.JsonNet;
using Nancy.Security;

namespace Api.Modules
{
    public class KursleiterKursModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KursleiterKursModule(KursleiterKursService kursleiterKursService)
            : base("/kursleiterKurse")
        {
            Get["/"] = p =>
            {
                var kursleiterKurse= kursleiterKursService.Get();
                return new JsonResponse(kursleiterKurse, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kursleiterKurs = kursleiterKursService.Get(p.id);
                if(kursleiterKurs == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kursleiterKurs, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                KursleiterKurs post = this.Bind();
                try
                {
                    var result = kursleiterKursService.Add(post);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            };

            Put["/"] = p =>
            {
                KursleiterKurs put = this.Bind();
                try
                {
                    var result = kursleiterKursService.Update(put);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            };

            Delete["/{id}"] = p =>
            {
                try
                {
                    var result = kursleiterKursService.Delete(p.id);
                    return new JsonResponse(result, new DefaultJsonSerializer());
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
