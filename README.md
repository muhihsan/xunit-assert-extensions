# xunit-assert-extensions

## How To Use
### Code
```
AssertAll.Execute(
	() => Assert.xxx(),
	() => Assert.xxx(),
	...
)
```
### Sample
```
AssertAll.Excecute(
    () => Assert.xxx(first assertion),
    () => Assert.xxx(second assertion),
    () => Assert.xxx(third assertion);
```
```
Message: 
    The following conditions failed:
    
    Xunit.Sdk.EqualException: Assert.Equal() Failure
    Expected: 4
    Actual:   1
       at Xunit.Assert.Equal[T](T expected, T actual, IEqualityComparer`1 comparer) in C:\Dev\xunit\xunit\src\xunit.assert\Asserts\EqualityAsserts.cs:line 40
       at ......
    
    Xunit.Sdk.EqualException: Assert.Equal() Failure
    Expected: 6
    Actual:   3
       at Xunit.Assert.Equal[T](T expected, T actual, IEqualityComparer`1 comparer) in C:\Dev\xunit\xunit\src\xunit.assert\Asserts\EqualityAsserts.cs:line 40
       at ......
       
  Stack Trace: 
    AssertAll.Exceute(Action[] assertionsToRun)
    DeleteDocumentHandlerTest.Handle_DocumentDontExist_ThrowsResourceValidationException()
    --- End of stack trace from previous location where exception was thrown ---
```