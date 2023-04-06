
public class StateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State initState)
    {
        currentState = initState;
        initState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();

        currentState = newState;

        newState.Enter();
    }
}
