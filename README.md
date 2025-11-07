# .NET Advanced

## Wprowadzenie

Witaj! To repozytorium kursu zaawansowanego programowania w C#.

Aby rozpocząć kurs, będziesz potrzebować:

1. [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
2. Sklonować to repozytorium git z GitHub.

## Klonowanie repozytorium kursu

```
git clone https://github.com/sulmar/...
```

## Przegląd projektów

To repozytorium zawiera wiele przykładowych projektów demonstrujących zaawansowane koncepcje C#. Każdy projekt skupia się na konkretnym temacie i zawiera praktyczne przykłady.

### Metody anonimowe

- **Delegates** - Demonstruje użycie delegatów, metod anonimowych, wyrażeń lambda i obsługi zdarzeń. Pokazuje jak subskrybować/odsubskrybować zdarzenia oraz używać delegatów do logowania i obliczania kosztów.

### Typy anonimowe

- **ConsoleApp** - Przykłady tworzenia i używania typów anonimowych w C# dla tymczasowych struktur danych.

### Programowanie asynchroniczne

- **AsyncAwaitExample** - Demonstruje wzorce async/await, tokeny anulowania i raportowanie postępu w operacjach asynchronicznych.
- **AsyncEnumerableExample** - Pokazuje jak używać asynchronicznych enumeratorów (IAsyncEnumerable) do asynchronicznego przesyłania strumieniowego danych.
- **PeriodicTimerExample** - Przykłady użycia PeriodicTimer do zaplanowanych zadań w tle.
- **TasksExample** - Demonstruje wzorce programowania asynchronicznego oparte na Task.
- **ThreadPoolExample** - Pokazuje jak używać ThreadPool do efektywnego zarządzania wątkami.
- **ThreadsExample** - Podstawowe przykłady wątków i zarządzanie cyklem życia wątków.

### Usługi w tle

- **BackgroundWorkerService** - Demonstruje tworzenie usług w tle używając wzorca .NET Hosted Services dla długotrwałych zadań w tle.

### Kanały

- **ChannelWorkerService** - Implementacja wzorca producent-konsument używając System.Threading.Channels do efektywnego przekazywania wiadomości między usługami.

### Kolekcje

- **Core** - Wspólne narzędzia i rozszerzenia do operacji na kolekcjach.
- **DictionaryExample** - Demonstruje użycie Dictionary<TKey, TValue> do szybkiego wyszukiwania klucz-wartość (np. wyszukiwanie pojazdu po numerze rejestracyjnym).
- **EnumeratorExample** - Własna implementacja enumeratora pokazująca jak tworzyć iterowalne kolekcje.
- **HashSetExample** - Przykłady użycia HashSet<T> dla kolekcji unikalnych elementów i operacji na zbiorach.
- **LazyCollectionExample** - Demonstruje wzorce leniwej ewaluacji z kolekcjami.
- **ListExample** - Przykłady operacji na List<T> włączając implementację koszyka zakupów.
- **QueueExample** - Przykłady użycia Queue<T> do operacji FIFO (First-In-First-Out) takich jak przetwarzanie zgłoszeń wsparcia.
- **SortedSetExample** - Przykłady SortedSet<T> do utrzymywania posortowanych unikalnych kolekcji.
- **StackExample** - Przykłady użycia Stack<T> do operacji LIFO (Last-In-First-Out).

### Kolekcje współbieżne

- **BlockingCollectionExample** - Bezpieczna dla wątków kolekcja dla scenariuszy producent-konsument z operacjami blokującymi.
- **ConcurrentBagExample** - Bezpieczna dla wątków nieuporządkowana kolekcja dla dostępu współbieżnego.
- **ConcurrentDictionaryExample** - Bezpieczny dla wątków słownik dla współbieżnych operacji klucz-wartość.
- **ConcurrentQueueExample** - Bezpieczna dla wątków implementacja kolejki dla scenariuszy współbieżnych.
- **ConsoleApp** - Aplikacja konsolowa demonstrująca użycie kolekcji współbieżnych.

### Typy dynamiczne

- **DynamicExample** - Demonstruje słowo kluczowe `dynamic` do rozwiązywania typów w czasie wykonania i pracy z danymi JSON.
- **DynamicObjectExample** - Własna implementacja DynamicObject dla dynamicznego zachowania.
- **ExpandoObjectExample** - Przykłady ExpandoObject do tworzenia obiektów z dynamicznymi właściwościami.

### Metody rozszerzające

- **ConsoleApp** - Demonstruje tworzenie i używanie metod rozszerzających do dodawania funkcjonalności do istniejących typów.

### Generatory danych testowych

- **BogusExample** - Przykłady użycia biblioteki Bogus do generowania fałszywych danych testowych.

### Podstawy

- **ExtensionMethodsExample** - Zaawansowane wzorce metod rozszerzających i najlepsze praktyki.
- **PartialClassExample** - Demonstruje klasy częściowe do dzielenia definicji klas na wiele plików.
- **WebApi** - Przykład Web API demonstrujący zaawansowane wzorce rozwoju aplikacji webowych w .NET.

### Typy generyczne

- **GenericClassses** - Przykłady tworzenia i używania klas generycznych (np. generyczne repozytoria).
- **GenericInterfaces** - Demonstruje interfejsy generyczne i ich implementacje.
- **GenericMethods** - Przykłady metod generycznych i ograniczeń typów.

### Łańcuchowanie metod

- **FluentApi** - Demonstruje wzorce projektowe fluent API używając łańcuchowania metod dla czytelnego kodu.

### Konstruktory główne

- **ConsoleApp** - Przykłady konstruktorów głównych C# wprowadzonych w nowszych wersjach C#.

### Refleksja

- **ActivatorExample** - Demonstruje użycie Activator.CreateInstance do dynamicznego tworzenia obiektów.
- **AttributeBasedProgramming** - Przykłady własnych atrybutów i wzorców programowania opartych na atrybutach.
- **GetSetExample** - Przykłady refleksji do dynamicznego pobierania i ustawiania właściwości.
- **MetaDataExample** - Praca z metadanymi typów używając refleksji.
- **PluginClass** - Przykład architektury wtyczek używającej refleksji do ładowania zewnętrznych zestawów.
- **ReflectionExample** - Kompleksowe przykłady refleksji włączając inspekcję typów, wywoływanie metod i eksport do CSV.

### Bezpieczne dla wątków kolekcje

- **BlockingCollectionExample** - Przykłady bezpiecznej dla wątków blokującej kolekcji.
- **ConcurrentBagExample** - Przykłady użycia ConcurrentBag.
- **ConcurrentDictionaryExample** - Przykłady bezpiecznego dla wątków słownika.
- **ConcurrentQueueExample** - Przykłady bezpiecznej dla wątków kolejki.

### Synchronizacja wątków

- **BarierExample** - Prymityw synchronizacji Barrier do koordynowania wielu wątków.
- **CountdownEventExample** - CountdownEvent do oczekiwania aż licznik osiągnie zero.
- **InterlockedExample** - Operacje atomowe używając klasy Interlocked dla bezpiecznych dla wątków operacji.
- **LockExample** - Przykłady instrukcji lock do synchronizacji wątków (np. wzorzec singleton).
- **MonitorExample** - Użycie klasy Monitor do synchronizacji wątków z większą kontrolą niż lock.
- **MutexExample** - Mutex do synchronizacji międzyprocesowej.
- **SemaphoreExample** - Semaphore do kontrolowania dostępu do puli zasobów.
- **SemaphoreProcess1** / **SemaphoreProcess2** - Przykłady semafora międzyprocesowego demonstrujące synchronizację między procesami.
- **SemaphoreSlimExample** - Lekki SemaphoreSlim do synchronizacji wewnątrzprocesowej.
