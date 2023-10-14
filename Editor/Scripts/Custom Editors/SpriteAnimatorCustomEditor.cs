using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SpriteAnimations.Editor
{
    [CustomEditor(typeof(SpriteAnimator))]
    public class SpriteAnimatorInspector : UnityEditor.Editor
    {
        #region Inspector

        [SerializeField]
        private MonoScript _scriptAsset;

        #endregion

        #region Fields

        private SpriteAnimator _spriteAnimator;

        #endregion

        #region GUI

        public override VisualElement CreateInspectorGUI()
        {
            _spriteAnimator = target as SpriteAnimator;

            VisualTreeAsset tree = Resources.Load<VisualTreeAsset>("UI Documents/SpriteAnimatorInspector");
            TemplateContainer inspector = tree.Instantiate();

            ObjectField scriptField = inspector.Query<ObjectField>("script-field");
            scriptField.SetEnabled(false);
            scriptField.value = _scriptAsset;


            Button openManagerButton = inspector.Query<Button>("open-manager-button");
            openManagerButton.clicked += () => AnimationsManagerWindow.OpenEditorWindow(_spriteAnimator);

            return inspector;
        }

        #endregion
    }
}