using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public interface ICandidateAccessor
    {
        int InsertCandidate(Candidate candidate);
        List<CandidateVM> SelectCandidatesByActive(bool active);
        CandidateVM SelectCandidateByCandidateID(int condidateID);
        List<CandidateVM> SelectCandidatesByElectionID(int electionID);
        int UpdateCandidate(Candidate oldCandidate, Candidate newCandidate);
        int DeactivateCandidate(int candidateID);
    }
}
