1. 声明式的将DOM绑定到底层Vue实例
2. Vue是响应式的
3. 只有Vue实例被创建时，property已在data中，数据才是响应式的，之后创建的不行
4. 一般先在fata中声明property，如果一开始它是空的，那么可以给它初始化为特殊值，如0，true, false等
5. 如何阻止响应，Object. freeze(property)
6. 指令
7. 条件与循环
8. 父作用域将数据传递给子组件props
9. 一个Vue应用的结构（一个根，根下有很多子组件，树结构）
10. 数据对象的使用，相当于引用方式，赋值给别人，别人变了我也变。
11. $，实例property与方法，是Vue实例的property, 如vm. $el, 其实它和绑定的DOM元素相等。方法就是Vue实例提供的方法，不是用户定义的
12. Vue中有this关键字，与面向对象语言一样的功能，但箭头函数中没有this，如created: () => console.log(this.a)，是错误写法
13. Vue实例生命周期：创建前，创建后，挂载（与DOM联系）前，已挂载，（有数据变化就：更新前，已更新，已挂载），销毁前，已销毁。

# 模板语法篇

    1. 什么是动态参数？指令的参数（html标签的属性）用[属性名]的形式绑定到data中，属性名对应的值是原生html的属性名称
       2. 动态参数值为字符串，默认null，其他类型触发警告，且不能有空格和引号，命名要全小写
       3. 什么是计算属性
       4. 什么是修饰符？以. 开头，作用于指令，阻止默认行为等操作
       5. 指令的缩写

# 计算属性和监听器

## 计算属性（computed）

1. 计算属性computed干嘛用的？处理复杂逻辑。如字符串反转。
2. 计算属性有点方法methods
3. 计算属性基于缓存，响应式依赖。
4. 方法每次都要重新运行函数
5. 默认有getter方法，可以设置setter方法

## 监听器（watch）

1. 监听属性等的变化开进行相应操作
2. 一些数据需要随着其它数据变动而变动时，用计算属性比较好
3. 当需要在数据变化时执行异步（访问一个 API）或开销较大的操作时，这个方式是最有用的。
4. 使用 `watch` 选项允许我们执行异步操作 (访问一个 API)，限制我们执行该操作的频率，并在我们得到最终结果前，设置中间状态。这些都是计算属性无法做到的。

# Class与Style绑定 v-bind

## 绑定HTML class:

1. 对象语法

   对象元素在data里

   在data里定义对象，直接绑定改对象

   可配合计算属性

2. 数组语法

   三元表达式

3. 数组语法+对象语法，对象放在数组里

4. 用在组件上

   当在一个自定义组件上使用 `class` property 时，这些 class 将被添加到该组件的根元素上面。这个元素上已经存在的 class 不会被覆盖。（只添加，不覆盖）

## 绑定内联样式style

1. 对象语法

   对象元素在data里

   在data里定义对象，直接绑定改对象

   可配合计算属性

2. 数组语法

3. 自动添加前缀

   当 `v-bind:style` 使用需要添加[浏览器引擎前缀](https://developer.mozilla.org/zh-CN/docs/Glossary/Vendor_Prefix)的 CSS property 时，如 `transform`，Vue.js 会自动侦测并添加相应的前缀。

4. 多重值

5. 从 2.3.0 起你可以为 `style` 绑定中的 property 提供一个包含多个值的数组，常用于提供多个带前缀的值。

6. **truthy**（真值）指的是在[布尔值](https://developer.mozilla.org/en-US/docs/Glossary/Boolean)上下文中，转换后的值为真的值。所有值都是真值，除非它们被定义为 [假值](https://developer.mozilla.org/en-US/docs/Glossary/Falsy)（即除 `false`、`0`、`""`、`null`、`undefined` 和 `NaN` 以外皆为真值）。

7. JavaScript 中的真值示例如下（将被转换为 true，`if` 后的代码段将被执行）：

   ```js
   if (true)
   if ({})
   if ([])
   if (42)
   if ("foo")
   if (new Date())
   if (-42)
   if (3.14)
   if (-3.14)
   if (Infinity)
   if (-Infinity)
   ```

# 条件渲染

## v-if

1. `v-if` 指令用于条件性地渲染一块内容。这块内容只会在指令的表达式返回 truthy 值的时候被渲染。

2. v-else

   `v-else` 元素必须紧跟在带 `v-if` 或者 `v-else-if` 的元素的后面，否则它将不会被识别。

3. 在 <template> 元素上使用 v-if 条件渲染分组

4. 用 key 管理可复用的元素

5. 高切换开销

## v-show

1. v-if：条件不满足，不会渲染，也不会出现在DOM中
2. v-show：条件不满足，不会渲染，还会出现在DOM中
3. 不支持<template>和v-else
4. 基于CSS切换
5. 高初始渲染开销

## v-if与v-for

1. 不推荐同时使用，v-for具有比v-if更高的优先级

# 列表渲染 v-for

## 用 v-for 把一个数组对应为一组元素

1. v-for

2. item in items语法

   (item, index) in items

   item of items

3. key控制item的复用性

## v-for遍历对象

1. value in object

2. (value, name) in object

   name是键名

3. (value, name, index) in object

   index是索引

## 维护状态

1. 当 Vue 正在更新使用 `v-for` 渲染的元素列表时，它默认使用“就地更新”的策略。如果数据项的顺序被改变，Vue 将不会移动 DOM 元素来匹配数据项的顺序，而是就地更新每个元素，并且确保它们在每个索引位置正确渲染
2. 建议尽可能在使用 `v-for` 时提供 `key` attribute

## 数组更新检测

### 变更方法

1. `push()`
2. `pop()`
3. `shift()`
4. `unshift()`
5. `splice()`
6. `sort()`
7. `reverse()`

### 替换数组

1. 非变更方法：返回新数组

   filter()

   concat()

   slice()

2. 当使用非变更方法时，可以用新数组替换旧数组。

3. Vue **不能检测**数组和对象的变化

## 显示过滤/排序后的结果（不改变原始数据）

1. 想要显示一个数组经过过滤或排序后的版本，而不实际变更或重置原始数据---->计算属性---->返回过滤或排序后的数组
2. 在计算属性不适用的情况下 (例如，在嵌套 `v-for` 循环中) 你可以使用方法。

## 在 v-for 里使用值范围

1. v-for="n in 10">{{ n }}

## 在 `<template>`上使用 v-for

## v-for 与 v-if 一同使用

1. 用v-if对v-for循环进行限制

## 在组件上使用 v-for

1. ```html
   <my-component
     v-for="(item, index) in items"
     v-bind:item="item"
     v-bind:index="index"
     v-bind:key="item.id"
   ></my-component>
   ```

2. 2.2.0+ 的版本里，当在组件上使用 `v-for` 时，**`key` 现在是必须的。**

3. is：好像用来引入组件

   注意这里的 `is="todo-item"` attribute。这种做法在使用 DOM 模板时是十分必要的，因为在` <ul>`元素内只有`<li>`元素会被看作有效内容，这样做实现的效果与 `<todo-item>` 相同，但是可以避开一些潜在的浏览器解析错误。

# 事件处理

## 监听事件