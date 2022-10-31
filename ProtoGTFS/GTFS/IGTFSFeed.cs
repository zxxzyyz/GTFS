using ProtoGTFS.GTFS.Collection;
using ProtoGTFS.GTFS.Entity;

namespace ProtoGTFS.GTFS
{
    public interface IGTFSFeed
    {
        void SetFeedInfo(FeedInfo feedInfo);

        FeedInfo GetFeedInfo();

        public IEntityCollection<Agency> Agency { get; }

        public IEntityCollection<AgencyJp> Agencyjp { get; }

        public IEntityCollection<Calendar> Calendar { get; }

        public IEntityCollection<CalendarDates> CalendarDates { get; }

        public IEntityCollection<FareAttributes> FareAttributes { get; }

        public IEntityCollection<FareRules> FareRules { get; }

        public IEntityCollection<Frequencies> Frequencies { get; }

        public IEntityCollection<OfficeJp> OfficeJp { get; }

        public IEntityCollection<Routes> Routes { get; }

        public IEntityCollection<RoutesJp> RoutesJp { get; }

        public IEntityCollection<Shapes> Shapes { get; }

        public IEntityCollection<StopTimes> StopTimes { get; }

        public IEntityCollection<Stops> Stops { get; }

        public IEntityCollection<Transfers> Transfers { get; }

        public IEntityCollection<Translations> Translations { get; }

        public IEntityCollection<Trips> Trips { get; }
    }
}
