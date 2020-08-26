using System;
using System.Collections.Generic;
using System.Linq;
using CSInterpreter.Event;

namespace CSInterpreter
{
    class Interpreter
    {
        public Interpreter(Parser parser)
        {
            this._parser = parser;
            // this._visitor = new TreeVisitor();
        }
        private Parser _parser;
        private TreeVisitor _visitor;
        private ICollection<IEvent> _events;
        private int visit(IAST tree)
        {
            return 0;
        }       
        // public int Interpret()
        // {
        //     IAST tree = this._parser.Parse();
        //     IAST result = this._visitor.ReduceTree(tree);
        //     return result.Token.Value;
        // }
    }
    class TreeVisitor : ITreeVisitor
    {
        public TreeVisitor(ICollection<IEvent> originalEvents)
        {
            this.originalEvents = originalEvents;
        }
        private IAST reducedTree;
        private ICollection<IEvent> resultedEvents;

        private ICollection<IEvent> originalEvents;
        // public IAST ProcessNode(IAST tree)
        // {
        //     tree.Accept(this);
        //     return resultedEvents;
        // }
        public void Visit(BinOp binOp)
        {

        }
        public void Visit(Num num)
        {

        }
        public void Visit (EndpointOp endpoint)
        {
            this.resultedEvents = this.originalEvents
                .Where( even =>  even.Id == endpoint.Token.StringValue).ToList();
        }
        public void Visit (StringOperand stringOperand)
        {

        }
        public void Visit(FreqOperator freqOperator)
        {
            freqOperator.Operand.Accept(this);
            // var window = new List<List<GenericEvent>>();
            var source = this.resultedEvents.OrderBy(x => x.Datetime);
            var result = source.Select(i => 
                source.SkipWhile(x => x != i)
                .TakeWhile(j => j.Datetime - i.Datetime <= TimeSpan.FromSeconds(12121))
            ).Where(x => x.Count() >= 2 && x.Count() <= 5)
            .Select(x => 
                new GenericEvent() {Datetime = x.Last().Datetime, RelatedEvents = (ICollection<IEvent>) x } );
            this.resultedEvents = (ICollection<IEvent>) result;
            // foreach (var item in source)
            // {
            //     var foundInWindow = source.SkipWhile(x => x != item)
            //         .TakeWhile(x => x.Datetime - item.Datetime <= TimeSpan.FromSeconds(12121))
            //         .ToList();
            //     if(foundInWindow.Count >= 2 && foundInWindow.size <= 5)
            //     window.Append(foundInWindow);
            // }
        }
        public void Visit(TTIOperator ttiOperator)
        {

        }
        public void Visit(IntervalOperator intervalOperator)
        {

        }
        public void Visit(EOperator eOperator)
        {

        }
        public void Visit(OROperator orOperator)
        {

        }

    }

}