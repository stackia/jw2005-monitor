using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using JW2005.DAL;
using JW2005.Models;

namespace JW2005.Controllers.API
{
    [EnableCors("*", "*", "*")]
    public class ServersController : ApiController
    {
        private static bool _isPinging;
        private readonly Jw2005Context _db = new Jw2005Context();
        private bool _disposeDb = true;

        public IEnumerable<Server> Get()
        {
            return _db.Servers;
        }

        public IHttpActionResult Get(int id)
        {
            var server = _db.Servers.Find(id);
            if (server == null)
                return NotFound();
            return Ok(server);
        }

        public IHttpActionResult Put()
        {
            if (_isPinging)
                return StatusCode(HttpStatusCode.NotModified);

            _isPinging = true;
            _disposeDb = false;
            Task.Run(() =>
            {
                try
                {
                    foreach (var server in _db.Servers.ToList())
                    {
                        try
                        {
                            var request = WebRequest.Create(string.Format("http://{0}/", server.Hostname));
                            request.Timeout = 5000;
                            using (var response = (HttpWebResponse) request.GetResponse())
                            {
                                server.Status = response.StatusCode == HttpStatusCode.OK
                                    ? ServerStatus.Online
                                    : ServerStatus.Down;
                            }
                        }
                        catch (WebException)
                        {
                            server.Status = ServerStatus.Down;
                        }
                        _db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                _isPinging = false;
                _db.Dispose();
            });
            return StatusCode(HttpStatusCode.Accepted);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _disposeDb)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}