using ProtoGTFS.GTFS;
using ProtoGTFS.GTFS.Collection;
using ProtoGTFS.GTFS.Entity;
using System.Collections.Generic;

namespace ProtoGTFS
{
    public class GTFSFeed : IGTFSFeed
    {
        private FeedInfo feedInfo;

        public GTFSFeed()
        {
            this.feedInfo = new FeedInfo();
            this.Agency = new UniqueEntityCollection<Agency>(new List<Agency>(),
                (e, id) => e.AgencyId == id);
            this.Agencyjp = new EntityCollection<AgencyJp>(new List<AgencyJp>(),
                (e, id, name) => e.AgencyId == id && e.AgencyOfficialName == name);
            this.Calendar = new UniqueEntityCollection<Calendar>(new List<Calendar>(),
                (e, id) => e.ServicedId == id);
            this.CalendarDates = new EntityCollection<CalendarDates>(new List<CalendarDates>(),
                (e, id, date) => e.ServiceId == id);
            this.FareAttributes = new EntityCollection<FareAttributes>(new List<FareAttributes>(),
                (e, id, currencyType) => e.FareId == id);
            this.FareRules = new UniqueEntityCollection<FareRules>(new List<FareRules>(),
                (e, id) => e.FareId == id);
            this.Frequencies = new EntityCollection<Frequencies>(new List<Frequencies>(),
                null);
            this.OfficeJp = new UniqueEntityCollection<OfficeJp>(new List<OfficeJp>(),
                (e, id) => e.OfficeId == id);
            this.Routes = new UniqueEntityCollection<Routes>(new List<Routes>(),
                (e, id) => e.RouteId == id);
            this.RoutesJp = new EntityCollection<RoutesJp>(new List<RoutesJp>(),
                (e, id, date) => e.RouteId == id && e.RouteUpdateDate == date);
            this.Shapes = new UniqueEntityCollection<Shapes>(new List<Shapes>(),
                (e, id) => e.ShapeId == id);
            this.StopTimes = new EntityCollection<StopTimes>(new List<StopTimes>(),
                (e, id, sequence) => e.StopId == id && e.StopSequence == sequence);
            this.Stops = new UniqueEntityCollection<Stops>(new List<Stops>(),
                (e, id) => e.StopsId == id);
            this.Transfers = new EntityCollection<Transfers>(new List<Transfers>(),
                (e, fromId, toId) => e.FromStopId == fromId && e.ToStopId == toId);
            this.Translations = new EntityCollection<Translations>(new List<Translations>(),
                (e, id, lang) => e.TransId == id && e.Lang == lang);
            this.Trips = new UniqueEntityCollection<Trips>(new List<Trips>(),
                (e, id) => e.TripId == id);
        }

        public void SetFeedInfo(FeedInfo feedInfo)
        {
            if (feedInfo != null)
            {
                this.feedInfo.FeedEndDate = feedInfo.FeedEndDate;
                this.feedInfo.FeedLang = feedInfo.FeedLang;
                this.feedInfo.FeedPublisherName = feedInfo.FeedPublisherName;
                this.feedInfo.FeedPublisherUrl = feedInfo.FeedPublisherUrl;
                this.feedInfo.FeedStartDate = feedInfo.FeedStartDate;
                this.feedInfo.FeedVersion = feedInfo.FeedVersion;
            }
        }

        public FeedInfo GetFeedInfo()
        {
            return this.feedInfo;
        }

        public IEntityCollection<Agency> Agency { get; private set; }

        public IEntityCollection<AgencyJp> Agencyjp { get; private set; }

        public IEntityCollection<Calendar> Calendar { get; private set; }

        public IEntityCollection<CalendarDates> CalendarDates { get; private set; }

        public IEntityCollection<FareAttributes> FareAttributes { get; private set; }

        public IEntityCollection<FareRules> FareRules { get; private set; }

        public IEntityCollection<Frequencies> Frequencies { get; private set; }

        public IEntityCollection<OfficeJp> OfficeJp { get; private set; }

        public IEntityCollection<Routes> Routes { get; private set; }

        public IEntityCollection<RoutesJp> RoutesJp { get; private set; }

        public IEntityCollection<Shapes> Shapes { get; private set; }

        public IEntityCollection<StopTimes> StopTimes { get; private set; }

        public IEntityCollection<Stops> Stops { get; private set; }

        public IEntityCollection<Transfers> Transfers { get; private set; }

        public IEntityCollection<Translations> Translations { get; private set; }

        public IEntityCollection<Trips> Trips { get; private set; }
    }
}
