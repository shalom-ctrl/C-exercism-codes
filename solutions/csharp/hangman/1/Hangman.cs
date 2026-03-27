using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Text;

public class HangmanState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public HangmanState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

public class TooManyGuessesException : Exception
{
}

public class Hangman
{
    private readonly BehaviorSubject<HangmanState> subject;
    private readonly string word;
    private HangmanState state;

    public IObservable<HangmanState> StateObservable => subject;
    public IObserver<char> GuessObserver => Observer.Create<char>(Process);

    private void Process(char c) {
        if(state.RemainingGuesses<=0) {
            subject.OnError(new TooManyGuessesException());
            return;
        }
        var nextState=GetNext(word, state, c);
        this.state=nextState;
        if (nextState.MaskedWord==word) {
            subject.OnCompleted();
        }
        else {
            subject.OnNext(nextState);
        }
    }

    private static HangmanState GetNext(string word, HangmanState state, char guess) {
        if(state.GuessedChars.Contains(guess)) {
            return new HangmanState(state.MaskedWord, state.GuessedChars, state.RemainingGuesses-1);
        }
        var sb=new StringBuilder(state.MaskedWord);
        var isCorrect=false;
        for(var i=0; i<word.Length; i++) {
            if(word[i]==guess) {
                sb[i]=guess;
                isCorrect=true;
            }
        }
        var nextMaskedWord=""+sb;
        var nextRemainingGuesses=state.RemainingGuesses-(isCorrect ? 0 : 1);
        return new HangmanState(nextMaskedWord, state.GuessedChars.Add(guess), nextRemainingGuesses);
    }
  
    public Hangman(string word)
    {
        var sb=new StringBuilder();
        sb.Append('_', word.Length);
        this.state=new HangmanState(""+sb, ImmutableHashSet<char>.Empty, 9);
        this.subject=new BehaviorSubject<HangmanState>(state);
        this.word=word;
    }
}