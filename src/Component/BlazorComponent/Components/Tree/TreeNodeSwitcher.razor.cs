﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorComponent
{
    public abstract partial class TreeNodeSwitcher<TItem> : ComponentBase
    {
        /// <summary>
        /// 树控件本身
        /// </summary>
        [CascadingParameter(Name = "Tree")]
        public Tree<TItem> TreeComponent { get; set; }

        /// <summary>
        /// 当前节点
        /// </summary>
        [CascadingParameter(Name = "SelfNode")]
        public TreeNode<TItem> SelfNode { get; set; }

        private bool IsShowLineIcon => !SelfNode.IsLeaf && TreeComponent.ShowLine;

        private bool IsShowSwitchIcon => !SelfNode.IsLeaf && !TreeComponent.ShowLine;

        /// <summary>
        /// 节点是否处于展开状态
        /// </summary>
        private bool IsSwitcherOpen => SelfNode.Expanded && !SelfNode.IsLeaf;

        /// <summary>
        /// 节点是否处于关闭状态
        /// </summary>
        private bool IsSwitcherClose => !SelfNode.Expanded && !SelfNode.IsLeaf;

        protected CssBuilder cssBuilder { get; } = new CssBuilder();

        private void SetClassMap()
        {
            cssBuilder.Clear().Add("ant-tree-switcher")
                .AddIf("ant-tree-switcher-noop", () => SelfNode.IsLeaf)
                .AddIf("ant-tree-switcher_open", () => IsSwitcherOpen)
                .AddIf("ant-tree-switcher_close", () => IsSwitcherClose);
        }

        protected override void OnInitialized()
        {
            SetClassMap();
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            SetClassMap();
            base.OnParametersSet();
        }

        [Parameter]
        public EventCallback<MouseEventArgs> OnSwitcherClick { get; set; }

        private async Task OnClick(MouseEventArgs args)
        {
            if (OnSwitcherClick.HasDelegate)
                await OnSwitcherClick.InvokeAsync(args);
        }
    }
}
