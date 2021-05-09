namespace ESF.Persistence
{
    using ESF.Domain;
    using System;

    public interface IRepository
    {
        T GetById<T>(Guid id) where T : EventStream, new();

        void Save(params EventStream[] evtStreamItems);
    }
}