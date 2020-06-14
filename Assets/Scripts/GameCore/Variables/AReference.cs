using UnityEngine;

namespace GameCore.Variables
{
    [System.Serializable]
    public abstract class AReference
    {
        [SerializeField] public bool UseReference = false;
    }

    [System.Serializable]
    public abstract class AReference<Ref, Var> : AReference where Ref : AVariable<Var>
    {
        //[SerializeField]protected bool UseReference = false;
        [SerializeField]protected Var Constant;
        [SerializeField]protected Ref Variable;

        public Var Value
        {
            get => UseReference ? Variable.Value : Constant;
            set
            {
                if (UseReference)
                    Variable.Value = value;
                else
                    Constant = value;
            }
        }
        
        public static implicit operator Var(AReference<Ref, Var> var)
        {
            return var.Value;
        }
    }
    
    
}