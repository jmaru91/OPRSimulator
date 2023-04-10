using ModestTree;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Zenject;

namespace OPR
{
    public class ZenjectCustomMenu
    {
        [MenuItem("Edit/Zenject/Output Object Graph For Current Scene")]
        public static void OutputObjectGraphForScene()
        {
            if (!EditorApplication.isPlaying)
            {
                Log.Error("Zenject error: Must be in play mode to generate object graph.  Hit Play button and try again.");
                return;
            }

            DiContainer container;
            try
            {
                container = ZenEditorUtil.GetCurrentSceneContextContainer();
            }
            catch (ZenjectException e)
            {
                Log.Error($"Unable to find container in current scene. {e.Message}");
                return;
            }

            var ignoreTypes = new List<Type>
            {
                typeof(DiContainer),
                typeof(InitializableManager),
                typeof(DisposableManager),
                typeof(ZenjectSceneLoader),
                typeof(SceneContext),
                typeof(ProjectKernel),
                typeof(SceneContextRegistry),
                typeof(ZenjectSettings),
            };
            IEnumerable<Type> contractTypes = GetAllContractTypesRecursive(container);
            ZenEditorUtil.OutputObjectGraphForCurrentScene(container, ignoreTypes, contractTypes);
        }

        static IEnumerable<Type> GetAllContractTypesRecursive(DiContainer container)
        {
            List<Type> contractTypes = GetAllContractTypes(container);
            foreach (DiContainer ancestor in container.AncestorContainers)
            {
                List<Type> ancestorContractTypes = GetAllContractTypes(ancestor);
                contractTypes.AddRange(ancestorContractTypes);
            }

            return contractTypes.Distinct();
        }

        static List<Type> GetAllContractTypes(DiContainer container)
        {
            return container.AllContracts.Select(a => a.Type).Where(a => !a.IsAbstract).ToList();
        }
    }
}
