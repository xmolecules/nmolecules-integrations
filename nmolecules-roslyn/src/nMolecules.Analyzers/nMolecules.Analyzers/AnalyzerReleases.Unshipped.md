### New Rules


Rule ID | Category | Severity | Notes
--------|----------|----------|-------|
XMoleculesAggregateRoot0001 | DDD      | Error    | AggregateRoot should not use repositories              
XMoleculesAggregateRoot0002 | DDD      | Error    | AggregateRoot should not use services                  
XMoleculesAggregateRoot0003 | DDD      | Error    | AggregateRoot should have id                           
XMoleculesEntity0001        | DDD      | Error    | Entity should not use repositories                     
XMoleculesEntity0002        | DDD      | Error    | Entity should not use aggregate roots                  
XMoleculesEntity0003        | DDD      | Error    | Entity should not use services                         
XMoleculesEntity0004        | DDD      | Error    | Entity should have id                                  
XMoleculesRepository0001    | DDD      | Error    | Repository should not use services                     
XMoleculesValueObject0001   | DDD      | Error    | ValueObject should not use entities                    
XMoleculesValueObject0002   | DDD      | Error    | ValueObject should not use services                    
XMoleculesValueObject0003   | DDD      | Error    | ValueObject should not use repositories                
XMoleculesValueObject0004   | DDD      | Error    | ValueObject should not use AggregateRoots              
XMoleculesValueObject0005   | DDD      | Error    | ValueObject should be immutable                        
XMoleculesValueObject1001   | DDD      | Error    | ValueObject should implement IEquatable (.net specific)
XMoleculesValueObject1002   | DDD      | Error    | ValueObject should be sealed (.net specific)           
