﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNLP.Tools.Util.Ling
{
    /// <summary>
    /// Set of common annotations for {@link CoreMap}s. The classes
    /// defined here are typesafe keys for getting and setting annotation
    /// values. These classes need not be instantiated outside of this
    /// class. e.g {@link TextAnnotation}.class serves as the key and a
    /// <code>string</code> serves as the value containing the corresponding word.
    /// 
    /// New types of {@link CoreAnnotation} can be defined anywhere that is
    /// convenient in the source tree - they are just classes. This file exists to
    /// hold widely used "core" annotations and others inherited from the
    /// {@link Label} family. In general, most keys should be placed in this file as
    /// they may often be reused throughout the code. This architecture allows for
    /// flexibility, but in many ways it should be considered as equivalent to an
    /// enum in which everything should be defined
    /// 
    /// The getType method required by CoreAnnotation must return the same class type
    /// as its value type parameter. It feels like one should be able to get away
    /// without that method, but because Java erases the generic type signature, that
    /// info disappears at runtime. See {@link ValueAnnotation} for an example.
    /// 
    /// @author dramage
    /// @author rafferty
    /// @author bethard
    /// 
    /// Code...
    /// </summary>
    public class CoreAnnotations
    {

        /// <summary>
        /// The CoreMap key identifying the annotation's text.
        /// 
        /// Note that this key is intended to be used with many different kinds of
        /// annotations - documents, sentences and tokens all have their own text.
        /// </summary>
        public class TextAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the lemma (morphological stem) of a token.
        /// This key is typically set on token annotations.
        /// TODO: merge with StemAnnotation?
        /// </summary>
        public class LemmaAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the Penn part of speech of a token.
        /// This key is typically set on token annotations.
        /// </summary>
        public class PartOfSpeechAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the token-level named entity tag (e.g., DATE, PERSON, etc.)
        /// This key is typically set on token annotations.
        /// </summary>
        public class NamedEntityTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the token-level named entity tag (e.g., DATE, PERSON, etc.) 
        /// from a previous NER tagger. NERFeatureFactory is sensitive to this tag 
        /// and will turn the annotations from the previous NER tagger into
        /// new features. This is currently used to implement one level of stacking --
        /// we may later change it to take a list as needed.
        /// This key is typically set on token annotations.
        /// </summary>
        public class StackedNamedEntityTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the token-level true case annotation (e.g., INIT_UPPER)
        /// This key is typically set on token annotations.
        /// </summary>
        public class TrueCaseAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the annotation's true-cased text.
        ///  Note that this key is intended to be used with many different kinds of
        /// annotations - documents, sentences and tokens all have their own text.
        /// </summary>
        public class TrueCaseTextAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the tokens contained by an annotation.
        /// This key should be set for any annotation that contains tokens. It can be
        /// done without much memory overhead using List.subList.
        /// </summary>
        public class TokensAnnotation : CoreAnnotation<List<CoreLabel>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreLabel>);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the tokens (can be words, phrases or anything that are of type CoreMap) contained by an annotation.
        /// This key should be set for any annotation that contains tokens (words, phrases etc). It can be
        /// done without much memory overhead using List.subList.
        /// </summary>
        public class GenericTokensAnnotation : CoreAnnotation<List<CoreMap>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreMap>);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the sentences contained by an annotation.
        /// This key is typically set only on document annotations.
        /// </summary>
        public class SentencesAnnotation : CoreAnnotation<List<CoreMap>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreMap>);
            }
        }

        /// <summary>
        /// The CoreMap key for getting the paragraphs contained by an annotation.
        /// This key is typically set only on document annotations.
        /// </summary>
        public class ParagraphsAnnotation : CoreAnnotation<List<CoreMap>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreMap>);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the first token included in an annotation.
        /// The token with index 0 is the first token in the document.
        /// This key should be set for any annotation that contains tokens.
        /// </summary>
        public class TokenBeginAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the last token after the end of an annotation.
        /// The token with index 0 is the first token in the document.
        /// This key should be set for any annotation that contains tokens.
        /// </summary>
        public class TokenEndAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the date and time associated with an annotation.
        /// This key is typically set on document annotations.
        /// </summary>
        public class CalendarAnnotation : CoreAnnotation<Calendar>
        {
            public Type GetAnnotationType()
            {
                return typeof (Calendar);
            }
        }

        /* These are the keys hashed on by IndexedWord */
        
        /// <summary>
        /// This refers to the unique identifier for a "document", 
        /// where document may vary based on your application.
        /// </summary>
        public class DocIdAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// This indexes a token number inside a sentence.  Standardly, tokens are
        /// indexed within a sentence starting at 1 (not 0: we follow common parlance
        /// whereby we speak of the first word of a sentence).
        /// This is generally an individual word or feature index - it is local, and
        /// may not be uniquely identifying without other identifiers such as sentence
        /// and doc. However, if these are the same, the index annotation should be a
        /// unique identifier for differentiating objects.
        /// </summary>
        public class IndexAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// This indexes the beginning of a span of words, e.g., a constituent in a
        /// tree. See {@link edu.stanford.nlp.trees.Tree#indexSpans(int)}.
        /// This annotation counts tokens.
        /// It standardly indexes from 1 (like IndexAnnotation).  The reasons for
        /// this are: (i) Talking about the first word of a sentence is kind of
        /// natural, and (ii) We use index 0 to refer to an imaginary root in dependency output.
        /// </summary>
        public class BeginIndexAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// This indexes the end of a span of words, e.g., a constituent in a tree.
        /// See {@link edu.stanford.nlp.trees.Tree#indexSpans(int)}. This annotation
        /// counts tokens.  It standardly indexes from 1 (like IndexAnnotation).
        /// The end index is not a fencepost: its value is equal to the
        /// IndexAnnotation of the last word in the span.
        /// </summary>
        public class EndIndexAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// This indicates that starting at this token, the sentence should not be ended until
        /// we see a ForcedSentenceEndAnnotation.  Used to force the ssplit annotator
        /// (eg the WordToSentenceProcessor) to keep tokens in the same sentence
        /// until ForcedSentenceEndAnnotation is seen.
        /// </summary>
        public class ForcedSentenceUntilEndAnnotation
            : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// This indicates the sentence should end at this token.
        /// Used to force the ssplit annotator (eg the WordToSentenceProcessor) to
        /// start a new sentence at the next token.
        /// </summary>
        public class ForcedSentenceEndAnnotation
            : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// Unique identifier within a document for a given sentence.
        /// </summary>
        public class SentenceIndexAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Line number for a sentence in a document delimited by newlines
        /// instead of punctuation.  May skip numbers if there are blank
        /// lines not represented as sentences.  Indexed from 1 rather than 0.
        /// </summary>
        public class LineNumberAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Contains the "value" - an ill-defined string used widely in MapLabel.
        /// </summary>
        public class ValueAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class CategoryAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The exact original surface form of a token.  This is created in the
        /// invertible PTBTokenizer. The tokenizer may normalize the token form to
        /// match what appears in the PTB, but this key will hold the original characters.
        /// </summary>
        public class OriginalTextAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Annotation for the whitespace characters appearing before this word.
        /// This can be filled in by the tokenizer so that the original text string can be reconstructed.
        /// </summary>
        public class BeforeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Annotation for the whitespace characters appear after this word. 
        /// This can be filled in by the tokenizer so that the original 
        /// text string can be reconstructed.
        /// </summary>
        public class AfterAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// CoNLL dep parsing - coarser POS tags.
        /// </summary>
        public class CoarseTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// CoNLL dep parsing - the dependency type
        /// </summary>
        public class CoNllDepAnnotation : CoreAnnotation<CoreMap>
        {
            public Type GetAnnotationType()
            {
                return typeof (CoreMap);
            }
        }
        
        /// <summary>
        /// CoNLL SRL/dep parsing - whether the word is a predicate
        /// </summary>
        public class CoNllPredicateAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// CoNLL SRL/dep parsing - map which, for the current word, 
        /// specifies its specific role for each predicate
        /// </summary>
        public class CoNllSrlAnnotation : CoreAnnotation<Dictionary<int, string>>
        {
            public Type GetAnnotationType()
            {
                return typeof (Dictionary<int, string>);
            }
        }

        /// <summary>
        /// CoNLL dep parsing - the dependency type
        /// </summary>
        public class CoNllDepTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// CoNLL dep parsing - the index of the word which is the parent of this word in the dependency tree
        /// </summary>
        public class CoNllDepParentIndexAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Inverse document frequency of the word this label represents
        /// </summary>
        public class IdfAnnotation : CoreAnnotation<Double>
        {
            public Type GetAnnotationType()
            {
                return typeof (Double);
            }
        }

        /* Keys from AbstractMapLabel (descriptions taken from that class) */
        
        /// <summary>
        /// The standard key for storing a projected category in the map, as a string.
        /// For any word (leaf node), the projected category is the syntactic category
        /// of the maximal constituent headed by the word. Used in SemanticGraph.
        /// </summary>
        public class ProjectedCategoryAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for a propbank label which is of type Argument
        /// </summary>
        public class ArgumentAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Another key used for propbank - to signify core arg nodes or predicate nodes
        /// </summary>
        public class MarkingAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for Semantic Head Word which is a String
        /// </summary>
        public class SemanticHeadWordAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for Semantic Head Word POS which is a String
        /// </summary>
        public class SemanticHeadTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Probank key for the Verb sense given in the Propbank Annotation, should only be in the verbnode
        /// </summary>
        public class VerbSenseAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for storing category with functional tags.
        /// </summary>
        public class CategoryFunctionalTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// This is an NER ID annotation (in case the all caps parsing didn't work out for you...)
        /// </summary>
        public class NerIdAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The key for the normalized value of numeric named entities.
        /// </summary>
        public class NormalizedNamedEntityTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public enum SRL_ID
        {
            ARG,
            NO,
            ALL_NO,
            REL
        }

        /// <summary>
        /// The key for semantic role labels (Note: please add to this description if you use this key)
        /// </summary>
        public class SrlIdAnnotation : CoreAnnotation<SRL_ID>
        {
            public Type GetAnnotationType()
            {
                return typeof (SRL_ID);
            }
        }

        /// <summary>
        /// The standard key for the "shape" of a word: a string representing the type
        /// of characters in a word, such as "Xx" for a capitalized word. See
        /// {@link edu.stanford.nlp.process.WordShapeClassifier} for functions for making shape strings.
        /// </summary>
        public class ShapeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The Standard key for storing the left terminal number relative to the root
        /// of the tree of the leftmost terminal dominated by the current node
        /// </summary>
        public class LeftTermAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// The standard key for the parent which is a String
        /// </summary>
        public class ParentAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class INAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for span which is an IntPair
        /// </summary>
        public class SpanAnnotation : CoreAnnotation<IntPair>
        {
            public Type GetAnnotationType()
            {
                return typeof (IntPair);
            }
        }

        /// <summary>
        /// The standard key for the answer which is a String
        /// </summary>
        public class AnswerAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }
        
        /// <summary>
        /// The standard key for gold answer which is a String
        /// </summary>
        public class GoldAnswerAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for the features which is a Collection
        /// </summary>
        public class FeaturesAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }
        
        /// <summary>
        /// The standard key for the semantic interpretation
        /// </summary>
        public class InterpretationAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for the semantic role label of a phrase.
        /// </summary>
        public class RoleAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The standard key for the gazetteer information
        /// </summary>
        public class GazetteerAnnotation : CoreAnnotation<List<string>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<string>);
            }
        }
        
        /// <summary>
        /// Morphological stem of the word this label represents
        /// </summary>
        public class StemAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class PolarityAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MorphoNumAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MorphoPersAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MorphoGenAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MorphoCaseAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// for Chinese: character level information, segmentation
        /// </summary>
        public class ChineseCharAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class ChineseOrigSegAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class ChineseSegAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Not sure exactly what this is, but it is different from
        /// ChineseSegAnnotation and seems to indicate if the text is segmented
        /// </summary>
        public class ChineseIsSegmentedAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the offset of the first character of an annotation.
        /// The character with index 0 is the first character in the document.
        /// This key should be set for any annotation that represents a span of text.
        /// </summary>
        public class CharacterOffsetBeginAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// The CoreMap key identifying the offset of the last character after the end
        /// of an annotation. The character with index 0 is the first character in the document.
        /// This key should be set for any annotation that represents a span of text.
        /// </summary>
        public class CharacterOffsetEndAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }
        
        /// <summary>
        /// Key for relative value of a word - used in RTE
        /// </summary>
        public class CostMagnificationAnnotation : CoreAnnotation<Double>
        {
            public Type GetAnnotationType()
            {
                return typeof (Double);
            }
        }

        public class WordSenseAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /*public class SRLInstancesAnnotation : CoreAnnotation<List<List<Pair<string, Pair>>>> {
    public Type getType() {
      return ErasureUtils.uncheckedCast(List.class);
    }
  }*/

        /// <summary>
        /// Used by RTE to track number of text sentences, to determine when hyp sentences begin.
        /// </summary>
        public class NumTxtSentencesAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Used in Trees
        /// </summary>
        public class TagLabelAnnotation : CoreAnnotation<Label>
        {
            public Type GetAnnotationType()
            {
                return typeof (Label);
            }
        }

        /// <summary>
        /// Used in CRFClassifier stuff PositionAnnotation should possibly be an int -
        /// it's present as either an int or string depending on context CharAnnotation
        /// may be "CharacterAnnotation" - not sure
        /// </summary>
        public class DomainAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class PositionAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class CharAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// This is not a catchall "unknown" annotation but seems to have a
        /// specific meaning for sequence classifiers
        /// </summary>
        public class UnknownAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class IDAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        // possibly this should be grouped with gazetteer annotation - original key was "gaz"
        public class GazAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class PossibleAnswersAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class DistSimAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class AbbrAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class ChunkAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class GovernorAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class AbgeneAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class GeniaAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class AbstrAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class FreqAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class DictAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class WebAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class FemaleGazAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MaleGazAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LastGazAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /* it really seems like this should have a different name or else be a boolean */

        public class IsURLAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LinkAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class MentionsAnnotation : CoreAnnotation<List<CoreMap>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreMap>);
            }
        }

        public class EntityTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /* it really seems like this should have a different name or else be a boolean */

        public class IsDateRangeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class PredictedAnswerAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /** Seems like this could be consolidated with something else... */

        public class OriginalAnswerAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /** Seems like this could be consolidated with something else... */

        public class OriginalCharAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class UTypeAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        public class EntityRuleAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Section of a document
        /// </summary>
        public class SectionAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Date for a section of a document
        /// </summary>
        public class SectionDateAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Id for a section of a document
        /// </summary>
        public class SectionIdAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Indicates that the token starts a new section and the attributes that should go into that section
        /// </summary>
        public class SectionStartAnnotation : CoreAnnotation<CoreMap>
        {
            public Type GetAnnotationType()
            {
                return typeof (CoreMap);
            }
        }

        /// <summary>
        /// Indicates that the token end a section and the label of the section
        /// </summary>
        public class SectionEndAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class WordPositionAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class ParaPositionAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class SentencePositionAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        // Why do both this and sentenceposannotation exist? I don't know, but one class
        // uses both so here they remain for now...
        public class SentenceIDAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class EntityClassAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class AnswerObjectAnnotation : CoreAnnotation<Object>
        {
            public Type GetAnnotationType()
            {
                return typeof (Object);
            }
        }

        /// <summary>
        /// Used in Task3 Pascal system
        /// </summary>
        public class BestCliquesAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class BestFullAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LastTaggedAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in wsd.supwsd package
        /// </summary>
        public class LabelAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /*public class NeighborsAnnotation : CoreAnnotation<List<Tuple<WordLemmaTag, string>>> {
    public Type getType() {
      return typeof(List<Tuple<WordLemmaTag, string>>);
    }
  }*/

        public class ContextsAnnotation : CoreAnnotation<List<Tuple<string, string>>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<Tuple<string, string>>);
            }
        }

        public class DependentsAnnotation :
            CoreAnnotation<List<Tuple<Tuple<string, String, string>, string>>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<Tuple<Tuple<string, String, string>, string>>);
            }
        }

        public class WordFormAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class TrueTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class SubcategorizationAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class BagOfWordsAnnotation : CoreAnnotation<List<Tuple<string, string>>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<Tuple<string, string>>);
            }
        }

        /// <summary>
        /// Used in srl.unsup
        /// </summary>
        public class HeightAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LengthAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in Gale2007ChineseSegmenter
        /// </summary>
        public class LBeginAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LMiddleAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LEndAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class D2_LBeginAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class D2_LMiddleAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class D2_LEndAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class UBlockAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in Chinese segmenters for whether there was space before a character.
        /// </summary>
        public class SpaceBeforeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /* Used in parser.discrim */

        /// <summary>
        /// The base version of the parser state, like NP or VBZ or ...
        /// </summary>
        public class StateAnnotation : CoreAnnotation<CoreLabel>
        {
            public Type GetAnnotationType()
            {
                return typeof (CoreLabel);
            }
        }

        /// <summary>
        /// Used in binarized trees to say the name of the most recent child
        /// </summary>
        public class PrevChildAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in binarized trees to specify the first child in the rule for which this node is the parent
        /// </summary>
        public class FirstChildAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// whether the node is the parent in a unary rule
        /// </summary>
        public class UnaryAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// annotation stolen from the lex parser
        /// </summary>
        public class DoAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// annotation stolen from the lex parser
        /// </summary>
        public class HaveAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// annotation stolen from the lex parser
        /// </summary>
        public class BeAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// annotation stolen from the lex parser
        /// </summary>
        public class NotAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// annotation stolen from the lex parser
        /// </summary>
        public class PercentAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// Specifies the base state of the parent of this node in the parse tree
        /// </summary>
        public class GrandparentAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// The key for storing a Head word as a string rather than a pointer 
        /// (as in TreeCoreAnnotations.HeadWordAnnotation)
        /// </summary>
        public class HeadWordStringAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in nlp.coref
        /// </summary>
        public class MonthAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class DayAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class YearAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in propbank.srl
        /// </summary>
        public class PriorAnnotation : CoreAnnotation<Dictionary<string, Double>>
        {
            public Type GetAnnotationType()
            {
                return typeof (Dictionary<string, Double>);
            }
        }

        public class SemanticWordAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class SemanticTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class CovertIDAnnotation : CoreAnnotation<List<IntPair>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<IntPair>);
            }
        }

        public class ArgDescendentAnnotation : CoreAnnotation<Tuple<string, Double>>
        {

            public Type GetAnnotationType()
            {
                return typeof (Tuple<string, Double>);
            }
        }

        /// <summary>
        /// Used in nlp.trees. When nodes are duplicated in Stanford Dependencies
        /// conversion (to represent conjunction of PPs with preposition collapsing,
        /// this gets set to a positive number on duplicated nodes.
        /// </summary>
        public class CopyAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Used in SimpleXMLAnnotator. The value is an XML element name string for the
        /// innermost element in which this token was contained.
        /// </summary>
        public class XmlElementAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in CleanXMLAnnotator.  The value is a list of XML element names indicating
        /// the XML tag the token was nested inside.
        /// </summary>
        public class XmlContextAnnotation : CoreAnnotation<List<string>>
        {

            public Type GetAnnotationType()
            {
                return typeof (List<string>);
            }
        }

        /// <summary>
        /// Used for Topic Assignments from LDA or its equivalent models.
        /// The value is the topic ID assigned to the current token.
        /// </summary>
        public class TopicAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Gets the synonymn of a word in the Wordnet (use a bit differently in sonalg's code)
        /// </summary>
        public class WordnetSynAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// to get words of the phrase
        /// </summary>
        public class PhraseWordsTagAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// to get pos tag of the phrase i.e. root of the phrase tree in the parse tree
        /// </summary>
        public class PhraseWordsAnnotation : CoreAnnotation<List<string>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<string>);
            }
        }

        /// <summary>
        /// to get prototype feature, see Haghighi Exemplar driven learning
        /// </summary>
        public class ProtoAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// which common words list does this word belong to
        /// </summary>
        public class CommonWordsAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        ///  Document date, Needed by SUTime
        /// </summary>
        public class DocDateAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Document type
        /// What kind of document is it: story, multi-part article, listing, email, etc
        /// </summary>
        public class DocTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Document source type
        /// What kind of place did the document come from: newswire, discussion forum, web...
        /// </summary>
        public class DocSourceTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Document title
        /// What is the document title
        /// </summary>
        public class DocTitleAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Reference location for the document
        /// </summary>
        public class LocationAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Author for the document
        /// (really should be a set of authors, but just have single string for simplicity)
        /// </summary>
        public class AuthorAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        // Numeric annotations

        /// <summary>
        /// Per token annotation indicating whether the token represents a NUMBER or ORDINAL
        /// (twenty first => NUMBER ORDINAL)
        /// </summary>
        public class NumericTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Per token annotation indicating the numeric value of the token
        /// (twenty first => 20 1)
        /// </summary>
        public class NumericValueAnnotation : CoreAnnotation<Double>
        {
            public Type GetAnnotationType()
            {
                return typeof (Double);
            }
        }

        /// <summary>
        /// Per token annotation indicating the numeric object associated with an annotation
        /// </summary>
        public class NumericObjectAnnotation : CoreAnnotation<Object>
        {
            public Type GetAnnotationType()
            {
                return typeof (Object);
            }
        }

        /// <summary>
        /// Annotation indicating whether the numeric phrase the token is part of
        /// represents a NUMBER or ORDINAL (twenty first => ORDINAL ORDINAL)
        /// </summary>
        public class NumericCompositeValueAnnotation : CoreAnnotation<Double>
        {
            public Type GetAnnotationType()
            {
                return typeof (Double);
            }
        }

        /// <summary>
        /// Annotation indicating the numeric value of the phrase the token is part of
        /// (twenty first => 21 21 )
        /// </summary>
        public class NumericCompositeTypeAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Annotation indicating the numeric object associated with an annotation
        /// </summary>
        public class NumericCompositeObjectAnnotation : CoreAnnotation<Object>
        {
            public Type GetAnnotationType()
            {
                return typeof (object);
            }
        }

        public class NumerizedTokensAnnotation : CoreAnnotation<List<CoreMap>>
        {
            public Type GetAnnotationType()
            {
                return typeof (List<CoreMap>);
            }
        }

        /// <summary>
        /// Used in dcoref to indicate that the it should use the discourse information annotated in the document
        /// </summary>
        public class UseMarkedDiscourseAnnotation : CoreAnnotation<Boolean>
        {
            public Type GetAnnotationType()
            {
                return typeof (Boolean);
            }
        }

        /// <summary>
        /// Used in dcoref to store discourse information. (marking <TURN> or quotation)
        /// </summary>
        public class UtteranceAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /// <summary>
        /// Used in dcoref to store speaker information.
        /// </summary>
        public class SpeakerAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        /// <summary>
        /// Used in dcoref to store paragraph information.
        /// </summary>
        public class ParagraphAnnotation : CoreAnnotation<int>
        {
            public Type GetAnnotationType()
            {
                return typeof (int);
            }
        }

        /**
   * used in dcoref.
   * to store premarked entity mentions.
   */
        /*public class MentionTokenAnnotation : CoreAnnotation<MultiTokenTag> {
    public Type getType() {
      return typeof(MultiTokenTag);
    }
  }*/

        /// <summary>
        /// Used in incremental DAG parser
        /// </summary>
        public class LeftChildrenNodeAnnotation : CoreAnnotation<SortedSet<Tuple<CoreLabel, string>>>
        {
            public Type GetAnnotationType()
            {
                return typeof (SortedSet<Tuple<CoreLabel, string>>);
            }
        }


        /// <summary>
        /// The CoreMap key identifying the annotation's antecedent.
        /// 
        /// The intent of this annotation is to go with words that have been
        /// linked via coref to some other entity.  For example, if "dog" is
        /// corefed to "cirrus" in the sentence "Cirrus, a small dog, ate an
        /// entire pumpkin pie", then "dog" would have the AntecedentAnnotation "cirrus".
        /// 
        /// This annotation is currently used ONLY in the KBP slot filling project.
        /// In that project, "cirrus" from the example above would also have an
        /// AntecedentAnnotation of "cirrus".
        /// Generally, you want to use the usual coref graph annotations
        /// </summary>
        public class AntecedentAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }

        public class LabelWeightAnnotation : CoreAnnotation<Double>
        {
            public Type GetAnnotationType()
            {
                return typeof (Double);
            }
        }

        public class ColumnDataClassifierAnnotation : CoreAnnotation<string>
        {
            public Type GetAnnotationType()
            {
                return typeof (string);
            }
        }
    }
}