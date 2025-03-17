

using System;
using System.Collections.Generic;
using System.Text;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;
using RentACarRESTGen.Infraestructure.Repository.RentACarREST;
using NHibernate;

namespace RentACarRESTGen.Infraestructure.CP
{
public class SessionCPNHibernate : GenericSessionCP
{
ITransaction tx;
public SessionCPNHibernate(object currentSession) : base (currentSession)
{
        this.CurrentSession = (ISession)currentSession;
}

public SessionCPNHibernate() : base ()
{
        this.CurrentSession = NHibernateHelper.OpenSession ();
}
public override void SessionInitializeTransaction ()
{
        if (CurrentSession == null) {
                CurrentSession = NHibernateHelper.OpenSession ();
        }
        tx = ((ISession)CurrentSession).BeginTransaction ();
}

public override void SessionInitializeWithoutTransaction ()
{
        if (CurrentSession == null) {
                CurrentSession = NHibernateHelper.OpenSession ();
        }
}

public override void Commit ()
{
        if (CurrentSession != null)
                tx.Commit ();
}

public override void RollBack ()
{
        if (CurrentSession != null && ((ISession)CurrentSession).IsOpen)
                tx.Rollback ();
}

public override void SessionClose ()
{
        if (CurrentSession != null && ((ISession)CurrentSession).IsOpen) {
                ((ISession)CurrentSession).Close ();
                ((ISession)CurrentSession).Dispose ();
                CurrentSession = null;
        }
}
}
}


