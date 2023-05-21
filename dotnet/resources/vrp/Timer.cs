using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/// <summary>
/// Timer-class
/// </summary>
public class TimerEx : Script
{

    /// <summary>A sorted List of Timers</summary>
    private static readonly List<TimerEx> timer = new List<TimerEx>();
    /// <summary>List used to put the Timers in timer-List after the possible List-iteration</summary>
    private static List<TimerEx> insertAfterList = new List<TimerEx>();
    /// <summary>Stopwatch to get the tick counts (Environment.TickCount is only int)</summary>
    private static Stopwatch stopwatch = new Stopwatch();

    /// <summary>The Action getting called by the Timer. Can be changed dynamically.</summary>
    public Action Func;
    /// <summary>After how many milliseconds (after the last execution) the timer should get called. Can be changed dynamically</summary>
    public readonly uint ExecuteAfterMs;
    /// <summary>When the Timer is ready to execute (Stopwatch is used).</summary>
    private ulong executeAtMs;
    /// <summary>How many executes the timer has left - use 0 for infinitely. Can be changed dynamically</summary>
    public uint ExecutesLeft;
    /// <summary>If the Timer should handle exceptions with a try-catch-finally. Can be changed dynamically</summary>
    public bool HandleException;
    /// <summary>If the Timer will get removed.</summary>
    private bool willRemoved = false;
    /// <summary>Use this to check if the timer is still running.</summary>
    public bool IsRunning
    {
        get
        {
            return !willRemoved;

        }
    }

    public TimerEx()
    {
        stopwatch.Start();
    }

    /// <param name="thefunc">The Action which you want to get called.</param>
    /// <param name="executeafterms">Execute the Action after milliseconds. If executes is more than one, this gets added to executeatms.</param>
    /// <param name="executeatms">Execute at milliseconds.</param>
    /// <param name="executes">How many times to execute. 0 for infinitely.</param>
    /// <param name="handleexception">If try-catch-finally should be used when calling the Action</param>
    private TimerEx(Action thefunc, uint executeafterms, ulong executeatms, uint executes, bool handleexception)
    {
        Func = thefunc;
        ExecuteAfterMs = executeafterms;
        executeAtMs = executeatms;
        ExecutesLeft = executes;
        HandleException = handleexception;
    }

    /// <summary>
    /// Use this method to create the Timer.
    /// </summary>
    /// <param name="thefunc">The Action which you want to get called.</param>
    /// <param name="executeafterms">Execute after milliseconds.</param>
    /// <param name="executes">Amount of executes. Use 0 for infinitely.</param>
    /// <param name="handleexception">If try-catch-finally should be used when calling the Action</param>
    /// <returns></returns>
    public static TimerEx SetTimer(Action thefunc, uint executeafterms, uint executes = 1, bool handleexception = true)
    {
        ulong executeatms = executeafterms + GetTick();
        TimerEx thetimer = new TimerEx(thefunc, executeafterms, executeatms, executes, handleexception);
        insertAfterList.Add(thetimer);   // Needed to put in the timer later, else it could break the script when the timer gets created from a Action of another timer.
        return thetimer;
    }

    private static ulong GetTick()
    {
        return (ulong)stopwatch.ElapsedMilliseconds;
    }

    public void Kill()
    {
        willRemoved = true;
    }

    private void ExecuteMe()
    {
        try
        {

      
        Func();
        if (ExecutesLeft == 1)
        {
            ExecutesLeft = 0;
            willRemoved = true;
        }
        else
        {
            if (ExecutesLeft != 0)
                ExecutesLeft--;
            executeAtMs += ExecuteAfterMs;
            insertAfterList.Add(this);
        }
        }
        catch (Exception)
        {

        }
    }


    private void ExecuteMeSafe()
    {
        try
        {
            Func();
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            NAPI.Util.ConsoleOutput("EXECUTE ME SAFE - " + ex.Message);
        }
        finally
        {
            if (ExecutesLeft == 1)
            {
                ExecutesLeft = 0;
                willRemoved = true;
            }
            else
            {
                if (ExecutesLeft != 0)
                    ExecutesLeft--;
                executeAtMs += ExecuteAfterMs;
                insertAfterList.Add(this);
            }
        }
    }

    /// <param name="changeexecutems">If the timer should change it's execute-time like it would have been executed now. Use false to ONLY execute it faster this time.</param>
    public void Execute(bool changeexecutems = true)
    {
        try
        {


            if (changeexecutems)
            {
                executeAtMs = GetTick();
            }
            if (HandleException)
                ExecuteMeSafe();
            else
                ExecuteMe();
        }
        catch (Exception)
        {

        }
    }

    private void InsertSorted()
    {
        try
        {


            bool putin = false;
            for (int i = timer.Count - 1; i >= 0 && !putin; i--)
                if (executeAtMs <= timer[i].executeAtMs)
                {
                    timer.Insert(i + 1, this);
                    putin = true;
                }

            if (!putin)
                timer.Insert(0, this);
        }
        catch (Exception)
        {

        }
    }

    [ServerEvent(Event.Update)]
    public static void OnUpdateFunc()
    {
        try
        {


            ulong tick = GetTick();
            for (int i = timer.Count - 1; i >= 0; i--)
            {
                if (!timer[i].willRemoved)
                {
                    if (timer[i].executeAtMs <= tick)
                    {
                        TimerEx thetimer = timer[i];
                        timer.RemoveAt(i);   // Remove the timer from the list (because of sorting and executeAtMs will get changed)
                        if (thetimer.HandleException)
                            thetimer.ExecuteMeSafe();
                        else
                            thetimer.ExecuteMe();
                    }
                    else
                        break;
                }
                else
                    timer.RemoveAt(i);
            }

            // Put the timers back in the list

            if (insertAfterList.Count > 0)
            {
                foreach (TimerEx timer in insertAfterList.ToList())
                {
                    try
                    {
                        timer.InsertSorted();

                    }
                    catch (Exception)
                    {

                    }
                }
                insertAfterList.Clear();
            }
        }
        catch (Exception)
        {

        }
    }
}


